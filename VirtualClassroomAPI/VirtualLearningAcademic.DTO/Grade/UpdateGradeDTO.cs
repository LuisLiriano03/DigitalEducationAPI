namespace VirtualLearningAcademic.DTO.Grade
{
    public class UpdateGradeDTO
    {
        public int GradeId { get; set; }
        public int? UserInformationId { get; set; }
        public int? CourseId { get; set; }
        public int? AssignmentId { get; set; }
        public int? Score { get; set; }
        public string? Comment { get; set; }
    }

}