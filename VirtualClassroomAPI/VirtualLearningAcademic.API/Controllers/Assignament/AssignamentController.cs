using Microsoft.AspNetCore.Mvc;
using VirtualLearningAcademic.API.Utility;
using VirtualLearningAcademic.BLL.Services.Contracts.Assignament;
using VirtualLearningAcademic.DTO.Assignament;

namespace VirtualLearningAcademic.API.Controllers.Assignament
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignamentController : ControllerBase
    {
        private readonly IAssignamentService _assignamentService;
        public AssignamentController(IAssignamentService assignamentService)
        {
            _assignamentService = assignamentService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetAssignament()
        {
            var response = new Response<List<GetAssignamentDTO>>();

            try
            {
                response.status = true;
                response.value = await _assignamentService.GetListAssignament();
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
        public async Task<IActionResult> SaveAssignament([FromBody] CreateAssignamentDTO assignament)
        {
            var response = new Response<GetAssignamentDTO>();

            try
            {
                response.status = true;
                response.value = await _assignamentService.CreateAssignament(assignament);
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
        public async Task<IActionResult> EditAssignament([FromBody] UpdateAssignamentDTO assignament)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _assignamentService.UpdateAssignament(assignament);
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
        public async Task<IActionResult> DeleteAssignament(int id)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _assignamentService.EliminateAssignament(id);
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