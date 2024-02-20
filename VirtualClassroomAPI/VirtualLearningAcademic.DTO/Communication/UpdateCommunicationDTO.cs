namespace VirtualLearningAcademic.DTO.Communication
{
    public class UpdateCommunicationDTO
    {
        public int CommunicationId { get; set; }
        public int? CourseId { get; set; }
        public int? UserInformationId { get; set; }
        public string? MessageCommunicactions { get; set; }
    }

}