namespace VirtualLearningAcademic.DTO.Assignament
{
    public class GetAssignamentDTO
    {
        public int AssignmentId { get; set; }
        public int? CourseId { get; set; }
        public string? DescriptionCourse { get; set; }
        public int? UserInformationId { get; set; }
        public string? DescriptionUser { get; set; }
        public string? Title { get; set; }
        public string? AssignmentDescription { get; set; }
        public string? DueDate { get; set; }
    }

}