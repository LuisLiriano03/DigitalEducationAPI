namespace VirtualLearningAcademic.DTO.Communication
{
    public class GetCommunicationDTO
    {
        public int CommunicationId { get; set; }
        public int? CourseId { get; set; }
        public string? DescriptionCourse { get; set; }
        public int? UserInformationId { get; set; }
        public string? DescriptionUser { get; set; }
        public string? MessageCommunicactions { get; set; }
    }

}