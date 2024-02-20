using VirtualLearningAcademic.DTO.ForumPost;

namespace VirtualLearningAcademic.BLL.Services.Contracts.ForumPost
{
    public interface IForumPostService
    {

        Task<List<GetForumPostDTO>> GetListForumPost();
        Task<GetForumPostDTO> CreateForumPost(CreateForumPostDTO model);
        Task<bool> UpdateForumPost(UpdateForumPostDTO model);
        Task<bool> EliminateForumPost(int id);
    }

}