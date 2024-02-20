namespace VirtualLearningAcademic.Model;

public partial class Assignment
{
    public int AssignmentId { get; set; }

    public int? CourseId { get; set; }

    public int? UserInformationId { get; set; }

    public string? Title { get; set; }

    public string? AssignmentDescription { get; set; }

    public DateTime? DueDate { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<Grade> Grades { get; } = new List<Grade>();

    public virtual UserInformation? UserInformation { get; set; }
}