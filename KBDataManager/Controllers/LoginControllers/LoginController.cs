using AutoMapper;
using KBDataAccessLibrary.DataAccess;
using KBDataAccessLibrary.Models.LoginModels;
using KBDataAccessLibrary.Models.RegisterModels;
using KBDataManager.EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public LoginController(KBContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }


        //LOGIN
        [HttpPost, Route("login")]
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


        //REGISTER-INVITATION
        [HttpPost, Route("invitation")]
        public IActionResult PostInvitation([FromBody] InvitationInputModel invitation)
        {
            Invitation newInvitation = new Invitation();
            var guid = Guid.NewGuid();
            var expireDate = DateTime.Now.AddDays(3);

            try
            {
                newInvitation.InvitationString = guid;
                newInvitation.Belt = invitation.Belt;
                newInvitation.Email = invitation.Email;

                newInvitation.AgeCategory = _context.AgeCategories.Find(invitation.AgeCategoryId);
                if (newInvitation.AgeCategory == null)
                {
                    return BadRequest();
                }

                newInvitation.Group = _context.Groups.Find(invitation.GroupId);
                if (newInvitation.Group == null)
                {
                    return BadRequest();
                }

                newInvitation.ExpireDate = expireDate;

                SendEmail(guid, invitation.Email);

                _context.Invitations.Add(newInvitation);
                _context.SaveChanges();

                SendEmail(guid,invitation.Email);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(invitation);
        }

        private void SendEmail(Guid guid,string email)
        {
            var message = new Message(new string[] { email }, "Cod Invitatie", guid.ToString());
            _emailSender.SendEmail(message);
        }
    }
}
