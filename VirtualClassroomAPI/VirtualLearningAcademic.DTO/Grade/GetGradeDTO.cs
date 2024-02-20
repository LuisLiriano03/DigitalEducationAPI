namespace VirtualLearningAcademic.DTO.Grade
{
    public class GetGradeDTO
    {
        public int GradeId { get; set; }
        public int? UserInformationId { get; set; }
        public string? DescriptionUser { get; set; }
        public int? CourseId { get; set; }
        public string? DescriptionCourse { get; set; }
        public int? AssignmentId { get; set; }
        public string? DescriptionAssignment { get; set; }
        public int? Score { get; set; }
        public string? Comment { get; set; }
    }

}