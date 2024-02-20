namespace VirtualLearningAcademic.Model;

public partial class Menu
{
    public int MenuId { get; set; }

    public string? NameMenu { get; set; }

    public string? Icon { get; set; }

    public string? MenuUrl { get; set; }

    public virtual ICollection<MenuRol> MenuRols { get; } = new List<MenuRol>();
}