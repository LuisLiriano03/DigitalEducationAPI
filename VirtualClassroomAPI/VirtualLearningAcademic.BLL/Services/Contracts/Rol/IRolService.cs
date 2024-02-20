using VirtualLearningAcademic.DTO.Rol;

namespace VirtualLearningAcademic.BLL.Services.Contracts.Rol
{
    public interface IRolService
    {
        Task<List<GetRolDTO>> GetAllRoles();
    }

}