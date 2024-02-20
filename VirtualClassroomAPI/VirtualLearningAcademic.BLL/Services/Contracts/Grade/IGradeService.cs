using VirtualLearningAcademic.DTO.Grade;

namespace VirtualLearningAcademic.BLL.Services.Contracts.Grade
{
    public interface IGradeService
    {
        Task<List<GetGradeDTO>> GetListGrade();
        Task<GetGradeDTO> CreateGrade(CreateGradeDTO model);
        Task<bool> UpdateGrade(UpdateGradeDTO model);
        Task<bool> EliminateGrade(int id);
    }

}