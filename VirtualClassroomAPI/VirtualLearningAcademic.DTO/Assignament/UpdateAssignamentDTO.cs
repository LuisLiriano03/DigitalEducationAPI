namespace VirtualLearningAcademic.DTO.Assignament
{
    public class UpdateAssignamentDTO
    {
        public int AssignmentId { get; set; }
        public string? Title { get; set; }
        public string? AssignmentDescription { get; set; }
        public string? DueDate { get; set; }
    }

}