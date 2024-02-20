using AutoMapper;
using VirtualLearningAcademic.BLL.Services.Contracts.Rol;
using VirtualLearningAcademic.DAL.Repository.Contracts;
using VirtualLearningAcademic.DTO.Rol;
using VirtualLearningAcademic.Model;

namespace VirtualLearningAcademic.BLL.Services.RolService
{
    public class RolService : IRolService
    {
        private readonly IGenericRepository<Rol> _rolRepository;
        private readonly IMapper _mapper;

        public RolService(IGenericRepository<Rol> rolRepository, IMapper mapper)
        {
            _rolRepository = rolRepository;
            _mapper = mapper;
        }

        public async Task<List<GetRolDTO>> GetAllRoles()
        {
            try
            {
                var listRoles = await _rolRepository.ValidateDataExistence();
                return _mapper.Map<List<GetRolDTO>>(listRoles.ToList());

            }
            catch
            {
                throw;
            }

        }

    }

}