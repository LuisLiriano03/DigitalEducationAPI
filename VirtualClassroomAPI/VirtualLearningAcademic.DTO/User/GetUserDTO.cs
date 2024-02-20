namespace VirtualLearningAcademic.DTO.User
{
    public class GetUserDTO
    {
        public int UserInformationId { get; set; }
        public string? FullName { get; set; }
        public int? Age { get; set; }
        public int? RolId { get; set; }
        public string? DescriptionRol { get; set; }
        public string? Email { get; set; }
        public string? UserPassword { get; set; }
        public int? IsActive { get; set; }
    }

}