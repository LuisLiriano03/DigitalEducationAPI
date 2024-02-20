using Microsoft.AspNetCore.Mvc;
using VirtualLearningAcademic.API.Utility;
using VirtualLearningAcademic.BLL.Services.Contracts.Forum;
using VirtualLearningAcademic.DTO.Forum;

namespace VirtualLearningAcademic.API.Controllers.Forum
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumController : ControllerBase
    {
        private readonly IForumService _forumService;
        public ForumController(IForumService forumService)
        {
            _forumService = forumService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetForum()
        {
            var response = new Response<List<GetForumDTO>>();

            try
            {
                response.status = true;
                response.value = await _forumService.GetListForum();
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
        public async Task<IActionResult> SaveForum([FromBody] CreateForumDTO forum)
        {
            var response = new Response<GetForumDTO>();

            try
            {
                response.status = true;
                response.value = await _forumService.CreateForum(forum);
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
        public async Task<IActionResult> EditForum([FromBody] UpdateForumDTO forum)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _forumService.UpdateForum(forum);
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
        public async Task<IActionResult> DeleteForum(int id)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _forumService.EliminateForum(id);
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