namespace VirtualLearningAcademic.DTO.Forum
{
    public class GetForumDTO
    {
        public int ForumId { get; set; }
        public int? CourseId { get; set; }
        public string? DescriptionCourse { get; set; }
        public string? Title { get; set; }
        public string? Descriptionforums { get; set; }
        public int? UserInformationId { get; set; }
        public string? DescriptionUser { get; set; }
    }

}