namespace VirtualLearningAcademic.DTO.StudentEnrollment
{
    public class GetStudentEnrollmentDTO
    {
        public int EnrollmentId { get; set; }
        public int? UserInformationId { get; set; }
        public string? DescriptionUser { get; set; }
        public int? CourseId { get; set; }
        public string? DescriptionCourse { get; set; }
    }

}