namespace VirtualLearningAcademic.Model;

public partial class ForumPost
{
    public int ForumPostId { get; set; }

    public int? ForumId { get; set; }

    public int? UserInformationId { get; set; }

    public string? PostText { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual Forum? Forum { get; set; }

    public virtual UserInformation? UserInformation { get; set; }
}