using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualLearningAcademic.API.Utility;
using VirtualLearningAcademic.BLL.Services.Contracts.Menu;
using VirtualLearningAcademic.DTO.Menu;

namespace VirtualLearningAcademic.API.Controllers.Menu
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuServices _menuServices;
        public MenuController(IMenuServices menuServices)
        {
            _menuServices = menuServices;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetMenu(int userId)
        {
            var response = new Response<List<GetMenuDTO>>();

            try
            {
                response.status = true;
                response.value = await _menuServices.GetListMenus(userId);
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