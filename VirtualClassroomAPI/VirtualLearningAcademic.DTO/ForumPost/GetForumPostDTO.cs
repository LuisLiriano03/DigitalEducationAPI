namespace VirtualLearningAcademic.DTO.ForumPost
{
    public class GetForumPostDTO
    {
        public int ForumPostId { get; set; }
        public int? ForumId { get; set; }
        public string? DescriptionForum { get; set; }
        public int? UserInformationId { get; set; }
        public string? DescriptionUser { get; set; }
        public string? PostText { get; set; }
    }

}