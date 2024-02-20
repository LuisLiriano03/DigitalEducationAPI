namespace VirtualLearningAcademic.DTO.Forum
{
    public class UpdateForumDTO
    {

        public int ForumId { get; set; }
        public int? CourseId { get; set; }
        public string? Title { get; set; }
        public string? Descriptionforums { get; set; }
        public int? UserInformationId { get; set; }
    }

}