namespace VirtualLearningAcademic.DTO.Assignament
{
    public class CreateAssignamentDTO
    {
        public int? CourseId { get; set; }
        public int? UserInformationId { get; set; }
        public string? Title { get; set; }
        public string? AssignmentDescription { get; set; }
        public string? DueDate { get; set; }
    }

}