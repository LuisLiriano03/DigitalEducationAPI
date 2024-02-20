using VirtualLearningAcademic.DTO.Assignament;

namespace VirtualLearningAcademic.BLL.Services.Contracts.Assignament
{
    public interface IAssignamentService
    {
        Task<List<GetAssignamentDTO>> GetListAssignament();
        Task<GetAssignamentDTO> CreateAssignament(CreateAssignamentDTO model);
        Task<bool> UpdateAssignament(UpdateAssignamentDTO model);
        Task<bool> EliminateAssignament(int id);
    }

}