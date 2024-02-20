namespace VirtualLearningAcademic.Model;

public partial class Rol
{
    public int RolId { get; set; }

    public string? NameRol { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual ICollection<MenuRol> MenuRols { get; } = new List<MenuRol>();

    public virtual ICollection<UserInformation> UserInformations { get; } = new List<UserInformation>();
}