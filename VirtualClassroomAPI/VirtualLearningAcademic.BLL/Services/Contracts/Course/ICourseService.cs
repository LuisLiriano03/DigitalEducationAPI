using VirtualLearningAcademic.DTO.Course;

namespace VirtualLearningAcademic.BLL.Services.Contracts.Course
{
    public interface ICourseService
    {
        Task<List<GetCourseDTO>> GetListCourse();
        Task<GetCourseDTO> CreateCourse(CreateCourseDTO model);
        Task<bool> UpdateCourse(UpdateCourseDTO model);
        Task<bool> EliminateCourse(int id);
    }

}