using AutoMapper;
using KBDataAccessLibrary.DataAccess;
using KBDataAccessLibrary.Models;
using KBDataAccessLibrary.Models.LoginModels;
using KBDataAccessLibrary.Models.RegisterModels;
using KBDataManager.EmailService;
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
using System.Threading.Tasks;

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
                    new Claim(ClaimTypes.Name, userInputModel.Username),
                    new Claim(ClaimTypes.Role, user.Role)
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
        [HttpPost, Route("invitation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Invitaion([FromBody] string email)
        {
            Random generator = new Random();
            String invitationCode = generator.Next(100000, 1000000).ToString("D6");

            string invitationHash = BCrypt.Net.BCrypt.HashPassword(invitationCode);
            SendEmailInvitation(email, invitationCode);
            return Ok(invitationHash);
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
                    newUser.Role = "client";
                }
                _context.Users.Add(newUser);

                var newStudent = _mapper.Map<UserRegistrationInputModel, Student>(userRegistration);
                newStudent.User = newUser;
                _context.Students.Add(newStudent);

                _context.SaveChanges();

                var name = userRegistration.LastName + " " + userRegistration.FirstName;
                SendEmailConfirmation(userRegistration.Username, name);

                return Ok();
            }
        }

        private void SendEmailConfirmation(string email, string name)
        {
            var message = new Message(new string[] { email }, "Confirmare solicitare", "Solicitarea pentru studentul " + name +" a fost trimisa" );
            _emailSender.SendEmail(message);
        }
    }
}
