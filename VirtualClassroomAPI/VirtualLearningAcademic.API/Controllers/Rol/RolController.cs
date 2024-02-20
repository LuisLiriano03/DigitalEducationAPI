using Microsoft.AspNetCore.Mvc;
using VirtualLearningAcademic.API.Utility;
using VirtualLearningAcademic.BLL.Services.Contracts.Rol;
using VirtualLearningAcademic.DTO.Rol;

namespace VirtualLearningAcademic.API.Controllers.Rol
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;
        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetRol()
        {
            var response = new Response<List<GetRolDTO>>();

            try
            {
                response.status = true;
                response.value = await _rolService.GetAllRoles();
            }
            catch (Exception ex)
            {
                response.status = false;
                response.mensage = ex.Message;
            }

            return Ok(response);

        }

    }

}