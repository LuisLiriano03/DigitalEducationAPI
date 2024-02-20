using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualLearningAcademic.API.Utility;
using VirtualLearningAcademic.BLL.Services.Contracts.ForumPost;
using VirtualLearningAcademic.DTO.Communication;
using VirtualLearningAcademic.DTO.ForumPost;

namespace VirtualLearningAcademic.API.Controllers.ForumPost
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumPostController : ControllerBase
    {
        private readonly IForumPostService _forumPostService;
        public ForumPostController(IForumPostService forumPostService)
        {
            _forumPostService = forumPostService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetForumPost()
        {
            var response = new Response<List<GetForumPostDTO>>();

            try
            {
                response.status = true;
                response.value = await _forumPostService.GetListForumPost();
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
        public async Task<IActionResult> SaveForumPost([FromBody] CreateForumPostDTO forum)
        {
            var response = new Response<GetForumPostDTO>();

            try
            {
                response.status = true;
                response.value = await _forumPostService.CreateForumPost(forum);
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
        public async Task<IActionResult> EditForumPost([FromBody] UpdateForumPostDTO forum)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _forumPostService.UpdateForumPost(forum);
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
        public async Task<IActionResult> DeleteForumPost(int id)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _forumPostService.EliminateForumPost(id);
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