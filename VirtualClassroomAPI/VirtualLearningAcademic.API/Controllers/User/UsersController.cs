using Microsoft.AspNetCore.Mvc;
using VirtualLearningAcademic.API.Utility;
using VirtualLearningAcademic.BLL.Services.Contracts.User;
using VirtualLearningAcademic.DTO.User;

namespace VirtualLearningAcademic.API.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetUsers()
        {
            var response = new Response<List<GetUserDTO>>();

            try
            {
                response.status = true;
                response.value = await _userService.GetAllUser();
            }
            catch (Exception ex)
            {
                response.status = false;
                response.mensage = ex.Message;
            }

            return Ok(response);

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDTO login)
        {
            var response = new Response<SessionDTO>();

            try
            {
                response.status = true;
                response.value = await _userService.ValidateCredentials(login.Email, login.UserPassword);
            }
            catch (Exception ex)
            {
                response.status = false;
                response.mensage = ex.Message;
            }

            return Ok(response);

        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveAdmin([FromBody] CreateUserDTO user)
        {
            var response = new Response<GetUserDTO>();

            try
            {
                response.status = true;
                response.value = await _userService.CreateUser(user);
            }
            catch (Exception ex)
            {
                response.status = false;
                response.mensage = ex.Message;
            }

            return Ok(response);

        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> EditAdmin([FromBody] UpdateUserDTO user)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _userService.UpdateUser(user);
            }
            catch (Exception ex)
            {
                response.status = false;
                response.mensage = ex.Message;
            }

            return Ok(response);

        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _userService.EliminateUser(id);
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