using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualLearningAcademic.BLL.Services.Contracts.Email;
using VirtualLearningAcademic.DTO.SendEmail;

namespace VirtualLearningAcademic.API.Controllers.Email
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(SendEmailDTO request)
        {
            _emailService.SendEmail(request);
            return Ok();

        }

    }

}
