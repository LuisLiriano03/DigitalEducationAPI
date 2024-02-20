namespace VirtualLearningAcademic.DTO.Course
{
    public class GetCourseDTO
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public int? UserInformationId { get; set; }
        public string? DescriptionUser { get; set; }
    }

}