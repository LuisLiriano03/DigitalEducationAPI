using VirtualLearningAcademic.DTO.Forum;

namespace VirtualLearningAcademic.BLL.Services.Contracts.Forum
{
    public interface IForumService
    {
        Task<List<GetForumDTO>> GetListForum();
        Task<GetForumDTO> CreateForum(CreateForumDTO model);
        Task<bool> UpdateForum(UpdateForumDTO model);
        Task<bool> EliminateForum(int id);
    }

}