using VirtualLearningAcademic.DTO.Communication;

namespace VirtualLearningAcademic.BLL.Services.Contracts.Communication
{
    public interface ICommunicationService
    {
        Task<List<GetCommunicationDTO>> GetListCommunication();
        Task<GetCommunicationDTO> CreateCommunication(CreateCommunicationDTO model);
        Task<bool> UpdateCommunication(UpdateCommunicationDTO model);
        Task<bool> EliminateCommunication(int id);
    }

}