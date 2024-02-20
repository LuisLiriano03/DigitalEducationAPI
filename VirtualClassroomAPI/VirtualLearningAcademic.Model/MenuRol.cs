namespace VirtualLearningAcademic.Model;

public partial class MenuRol
{
    public int MenuIdRol { get; set; }

    public int? MenuId { get; set; }

    public int? RolId { get; set; }

    public virtual Menu? Menu { get; set; }

    public virtual Rol? Rol { get; set; }
}