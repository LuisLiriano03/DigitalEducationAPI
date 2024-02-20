namespace VirtualLearningAcademic.Model;

public partial class Grade
{
    public int GradeId { get; set; }

    public int? UserInformationId { get; set; }

    public int? CourseId { get; set; }

    public int? AssignmentId { get; set; }

    public int? Score { get; set; }

    public DateTime? GradeDate { get; set; }

    public string? Comment { get; set; }

    public virtual Assignment? Assignment { get; set; }

    public virtual Course? Course { get; set; }

    public virtual UserInformation? UserInformation { get; set; }
}