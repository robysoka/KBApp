using KBDataManager.EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KBDataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailTestController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        public EmailTestController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var message = new Message(new string[] { "robert.hadadea@gmail.com","radu.turtoi@yahoo.com" }, "Test email", "Va saluta Sensei");
            _emailSender.SendEmail(message);
            return Ok();
        }
    }
}
