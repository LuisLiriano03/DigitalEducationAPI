using VirtualLearningAcademic.DTO.SendEmail;

namespace VirtualLearningAcademic.BLL.Services.Contracts.Email
{
    public interface IEmailService
    {
        void SendEmail(SendEmailDTO request);
    }

}
