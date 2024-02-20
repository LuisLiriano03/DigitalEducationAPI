using VirtualLearningAcademic.DTO.Menu;

namespace VirtualLearningAcademic.BLL.Services.Contracts.Menu
{
    public interface IMenuServices
    {
        Task<List<GetMenuDTO>> GetListMenus(int userId);
    }

}