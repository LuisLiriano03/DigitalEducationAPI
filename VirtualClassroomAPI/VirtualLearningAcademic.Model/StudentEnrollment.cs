namespace VirtualLearningAcademic.Model;

public partial class StudentEnrollment
{
    public int EnrollmentId { get; set; }

    public int? UserInformationId { get; set; }

    public int? CourseId { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual Course? Course { get; set; }

    public virtual UserInformation? UserInformation { get; set; }
}