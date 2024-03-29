﻿using AutoMapper;
using KBDataAccessLibrary.DataAccess;
using KBDataAccessLibrary.Models;
using KBDataManager.EmailService;
using KBDataManager.InputModels;
using KBDataManager.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace KBDataManager.Controllers.LoginControllers
{
    [Route("api/auth")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly KBContext _context;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        public LoginController(KBContext context, IEmailSender emailSender, IMapper mapper)
        {
            _context = context;
            _emailSender = emailSender;
            _mapper = mapper;

        }


        //LOGIN
        /// <summary>
        /// Returns JWT
        /// </summary>
        /// <response code="200">Returns token</response>
        /// <response code="400">Invalid client request</response>
        /// <response code="401">There's no account with the specified username. Try again! / Password is wrong!</response>
        /// <param name="userInputModel"></param>
        /// <returns></returns>
        [HttpPost, Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Login([FromBody] UserInputModel userInputModel)
        {
            if (userInputModel == null)
            {
                return BadRequest("Invalid client request");
            }

            var user = GetUser(userInputModel.Username);
            if (user == null)
            {
                return Unauthorized("There's no account with the specified username. Try again!");
            }

            if (userInputModel.Password == user.Password)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("IsSecretKeyBroTakeCare"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim("username", userInputModel.Username),
                    new Claim("role", user.Role)
                };

                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44386",
                    audience: "https://localhost:44386",
                    claims: claims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized("Password is wrong");
            }
        }

        private User GetUser(string Username)
        {
            return _context.Users.Find(Username);
        }

        //INVITATION CODE ENCTYPTION
        /// <summary>
        /// Returns the hashed version of the invitation
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost, Route("invitation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Invitaion([FromBody]InvitationInputModel email)
        {
            if (UserExists(email.Email))
            {
                return Unauthorized("There is already an account with the given email");
            }
          
            try
            {
                Random generator = new Random();
                String invitationCode = generator.Next(100000, 1000000).ToString("D6");
                string hash = BCrypt.Net.BCrypt.HashPassword(invitationCode);
                SendEmailInvitation(email.Email, invitationCode);

                InvitationHash invitationHash = new InvitationHash();
                invitationHash.Hash = hash;
                return Ok(invitationHash);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        private bool UserExists(string username)
        {
            return _context.Users.Any(e => e.Username == username);
        }
        private void SendEmailInvitation(string email, String invitationCode)
        {
            var message = new Message(new string[] { email }, "Cod Invitatie", invitationCode);
            _emailSender.SendEmail(message);
        }

        //REGISTER
        [HttpPost, Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Register([FromBody] UserRegistrationInputModel userRegistration)
        {
            try
            {

                bool verified = BCrypt.Net.BCrypt.Verify(userRegistration.InvitationCode, userRegistration.InvitationHash);
                if (!verified)
                {
                    return Forbid();
                }
                else
                {

                    var newUser = _mapper.Map<UserRegistrationInputModel, User>(userRegistration);
                    if (newUser.Role == null)
                    {
                        newUser.Role = "USER";
                    }
                    _context.Users.Add(newUser);

                    var newStudent = _mapper.Map<UserRegistrationInputModel, Student>(userRegistration);
                    if(newStudent.Belt == null)
                    {
                        newStudent.Belt = "alb";
                    }
                    newStudent.GroupId = userRegistration.GroupId;
                    newStudent.User = newUser;
                    _context.Students.Add(newStudent);

                    _context.SaveChanges();

                    var name = userRegistration.LastName + " " + userRegistration.FirstName;

                    SendEmailConfirmation(userRegistration.Username, name);

                    return Ok();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private void SendEmailConfirmation(string email, string name)
        {
            var message = new Message(new string[] { email }, "Confirmare solicitare", "Contul pentru " + name +" a fost creat" );
            _emailSender.SendEmail(message);
        }


        //USER CONFIRMATION
        //CONFIRM
        [HttpPut, Route("confirm/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult userConfirm(string username)
        {
            var user = _context.Users.Find(username);

            if (user == null)
            {
                return NotFound("There is no user with the specifed username");
            }

            if(user.IsVerified == true)
            {
                return BadRequest("User already validated");
            }
           
            user.IsVerified = true;
            _context.Entry(user).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        //REJECT
        [HttpDelete, Route("reject/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult userReject(string username)
        {
            var user = _context.Users.Find(username);

            if (user == null)
            {
                return NotFound("There is no user with the specifed username");
            }

            if (user.IsVerified == true)
            {
                return BadRequest("User already validated");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok();
        }
    }
}
