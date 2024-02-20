using VirtualLearningAcademic.DTO.StudentEnrollment;

namespace VirtualLearningAcademic.BLL.Services.Contracts.StudentEnrollment
{
    public interface IStudentEnrollmentService
    {
        Task<List<GetStudentEnrollmentDTO>> GetListEnrollment();
        Task<GetStudentEnrollmentDTO> CreateEnrollment(CreateStudentEnrollmentDTO model);
        Task<bool> UpdateEnrollment(UpdateStudentEnrollmentDTO model);
        Task<bool> EliminateEnrollment(int id);
    }

}