namespace VirtualLearningAcademic.Model;

public partial class UserInformation
{
    public int UserInformationId { get; set; }

    public string? FullName { get; set; }

    public int? Age { get; set; }

    public int? RolId { get; set; }

    public string? Email { get; set; }

    public string? UserPassword { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual ICollection<Assignment> Assignments { get; } = new List<Assignment>();

    public virtual ICollection<Communication> Communications { get; } = new List<Communication>();

    public virtual ICollection<Course> Courses { get; } = new List<Course>();

    public virtual ICollection<ForumPost> ForumPosts { get; } = new List<ForumPost>();

    public virtual ICollection<Forum> Forums { get; } = new List<Forum>();

    public virtual ICollection<Grade> Grades { get; } = new List<Grade>();

    public virtual Rol? Rol { get; set; }

    public virtual ICollection<StudentEnrollment> StudentEnrollments { get; } = new List<StudentEnrollment>();
}