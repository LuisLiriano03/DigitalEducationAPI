using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VirtualLearningAcademic.BLL.Services.Contracts.User;
using VirtualLearningAcademic.DAL.Repository.Contracts;
using VirtualLearningAcademic.DTO.User;
using VirtualLearningAcademic.Model;

namespace VirtualLearningAcademic.BLL.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<UserInformation> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<UserInformation> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<GetUserDTO>> GetAllUser()
        {
            try
            {
                var userQuery = await _userRepository.ValidateDataExistence();
                var listUser = userQuery.Include(rol => rol.Rol).ToList();

                return _mapper.Map<List<GetUserDTO>>(listUser);
            }
            catch
            {
                throw;
            }

        }

        public async Task<SessionDTO> ValidateCredentials(string email, string password)
        {
            try
            {
                var userQuery = await _userRepository.ValidateDataExistence(u => 
                    u.Email == email && 
                    u.UserPassword == password);

                if (userQuery.FirstOrDefault() == null)
                    throw new TaskCanceledException("El usuario no existe");

                UserInformation RetrieveUser = userQuery.Include(rol => rol.Rol).First();

                return _mapper.Map<SessionDTO>(RetrieveUser);

            }
            catch
            {
                throw;
            }

        }

        public async Task<GetUserDTO> CreateUser(CreateUserDTO model)
        {
            try
            {
                var userCreated = await _userRepository.CreateData(_mapper.Map<UserInformation>(model));

                if (userCreated.UserInformationId == 0)
                    throw new TaskCanceledException("No se pudo crear");

                var query = await _userRepository.ValidateDataExistence(u => 
                    u.UserInformationId == userCreated.UserInformationId);

                userCreated = query.Include(rol => rol.Rol).First();

                return _mapper.Map<GetUserDTO>(userCreated);

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> UpdateUser(UpdateUserDTO model)
        {
            try
            {
                var userModel = _mapper.Map<UserInformation>(model);

                var userFound = await _userRepository.GetDataDetails(u => 
                    u.UserInformationId == userModel.UserInformationId);

                if (userFound == null)
                    throw new TaskCanceledException("El usuario no existe");

                userFound.FullName = userModel.FullName;
                userFound.Age= userModel.Age;
                userFound.RolId = userModel.RolId;
                userFound.Email = userModel.Email;
                userFound.UserPassword = userModel.UserPassword;
                userFound.IsActive = userModel.IsActive;

                bool response = await _userRepository.UpdateData(userFound);

                if (!response)
                    throw new TaskCanceledException("No se pudo editar");

                return response;

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> EliminateUser(int id)
        {
            try
            {
                var userFound = await _userRepository.GetDataDetails(u => u.UserInformationId == id);

                if (userFound == null)
                    throw new TaskCanceledException("El usuario no existe");

                bool response = await _userRepository.RemoveData(userFound);

                if (!response)
                    throw new TaskCanceledException("No se pudo eliminar");

                return response;
            }
            catch
            {
                throw;
            }

        }
        
    }

}