using AutoMapper;
using VirtualLearningAcademic.BLL.Services.Contracts.Menu;
using VirtualLearningAcademic.DAL.Repository.Contracts;
using VirtualLearningAcademic.DTO.Menu;
using VirtualLearningAcademic.Model;

namespace VirtualLearningAcademic.BLL.Services.MenuService
{
    public class MenuService : IMenuServices
    {
        private readonly IGenericRepository<UserInformation> _usuarioRepositorio;
        private readonly IGenericRepository<MenuRol> _menuRolRepositorio;
        private readonly IGenericRepository<Menu> _menuRepositorio;
        private readonly IMapper _mapper;

        public MenuService(
            IGenericRepository<UserInformation> usuarioRepositorio, 
            IGenericRepository<MenuRol> menuRolRepositorio, 
            IGenericRepository<Menu> menuRepositorio, 
            IMapper mapper)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _menuRolRepositorio = menuRolRepositorio;
            _menuRepositorio = menuRepositorio;
            _mapper = mapper;
        }

        public async Task<List<GetMenuDTO>> GetListMenus(int userId)
        {
            IQueryable<UserInformation> tbUser = await _usuarioRepositorio.ValidateDataExistence(u => 
                u.UserInformationId == userId);

            IQueryable<MenuRol> tbMenuRol = await _menuRolRepositorio.ValidateDataExistence();
            IQueryable<Menu> tbMenu = await _menuRepositorio.ValidateDataExistence();

            try
            {
                IQueryable<Menu> tbResul = (from u in tbUser
                                                join mr in tbMenuRol on u.RolId equals mr.RolId
                                                join m in tbMenu on mr.MenuId equals m.MenuId
                                                select m).AsQueryable();

                var listMenus = tbResul.ToList();

                return _mapper.Map<List<GetMenuDTO>>(listMenus);
            }
            catch
            {
                throw;
            }

        }

    }

}