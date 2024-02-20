using VirtualLearningAcademic.DTO.User;

namespace VirtualLearningAcademic.BLL.Services.Contracts.User
{
    public interface IUserService
    {
        Task<List<GetUserDTO>> GetAllUser();
        Task<SessionDTO> ValidateCredentials(string email, string password);
        Task<GetUserDTO> CreateUser(CreateUserDTO model);
        Task<bool> UpdateUser(UpdateUserDTO model);
        Task<bool> EliminateUser(int id);
    }

}