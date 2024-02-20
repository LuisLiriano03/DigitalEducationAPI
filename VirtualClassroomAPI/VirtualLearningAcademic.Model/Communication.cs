namespace VirtualLearningAcademic.Model;

public partial class Communication
{
    public int CommunicationId { get; set; }

    public int? CourseId { get; set; }

    public int? UserInformationId { get; set; }

    public string? MessageCommunicactions { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual Course? Course { get; set; }

    public virtual UserInformation? UserInformation { get; set; }
}