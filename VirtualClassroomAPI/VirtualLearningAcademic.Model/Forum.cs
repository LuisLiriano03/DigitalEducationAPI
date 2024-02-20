namespace VirtualLearningAcademic.Model;

public partial class Forum
{
    public int ForumId { get; set; }

    public int? CourseId { get; set; }

    public string? Title { get; set; }

    public string? Descriptionforums { get; set; }

    public int? UserInformationId { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<ForumPost> ForumPosts { get; } = new List<ForumPost>();

    public virtual UserInformation? UserInformation { get; set; }
}