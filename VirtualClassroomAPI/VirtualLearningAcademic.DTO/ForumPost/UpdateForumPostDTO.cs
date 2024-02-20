namespace VirtualLearningAcademic.DTO.ForumPost
{
    public class UpdateForumPostDTO
    {
        public int ForumPostId { get; set; }
        public int? ForumId { get; set; }
        public int? UserInformationId { get; set; }
        public string? PostText { get; set; }
    }

}