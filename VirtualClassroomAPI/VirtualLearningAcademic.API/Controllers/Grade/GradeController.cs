using Microsoft.AspNetCore.Mvc;
using VirtualLearningAcademic.API.Utility;
using VirtualLearningAcademic.BLL.Services.Contracts.Grade;
using VirtualLearningAcademic.DTO.Grade;

namespace VirtualLearningAcademic.API.Controllers.Grade
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;
        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetGrade()
        {
            var response = new Response<List<GetGradeDTO>>();

            try
            {
                response.status = true;
                response.value = await _gradeService.GetListGrade();
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
        public async Task<IActionResult> SaveGrade([FromBody] CreateGradeDTO grade)
        {
            var response = new Response<GetGradeDTO>();

            try
            {
                response.status = true;
                response.value = await _gradeService.CreateGrade(grade);
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
        public async Task<IActionResult> EditGrade([FromBody] UpdateGradeDTO grade)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _gradeService.UpdateGrade(grade);
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
        public async Task<IActionResult> DeleteGrade(int id)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _gradeService.EliminateGrade(id);
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