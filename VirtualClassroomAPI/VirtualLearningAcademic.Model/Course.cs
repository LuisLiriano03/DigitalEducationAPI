namespace VirtualLearningAcademic.Model;

public partial class Course
{
    public int CourseId { get; set; }

    public string? CourseName { get; set; }

    public int? UserInformationId { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual ICollection<Assignment> Assignments { get; } = new List<Assignment>();

    public virtual ICollection<Communication> Communications { get; } = new List<Communication>();

    public virtual ICollection<Forum> Forums { get; } = new List<Forum>();

    public virtual ICollection<Grade> Grades { get; } = new List<Grade>();

    public virtual ICollection<StudentEnrollment> StudentEnrollments { get; } = new List<StudentEnrollment>();

    public virtual UserInformation? UserInformation { get; set; }
}