namespace VirtualLearningAcademic.DTO.User
{
    public class CreateUserDTO
    {
        public string? FullName { get; set; }
        public int? Age { get; set; }
        public int? RolId { get; set; }
        public string? Email { get; set; }
        public string? UserPassword { get; set; }
    }

}