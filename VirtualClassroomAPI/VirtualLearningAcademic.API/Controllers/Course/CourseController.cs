using Microsoft.AspNetCore.Mvc;
using VirtualLearningAcademic.API.Utility;
using VirtualLearningAcademic.BLL.Services.Contracts.Course;
using VirtualLearningAcademic.DTO.Course;

namespace VirtualLearningAcademic.API.Controllers.Course
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetCourse()
        {
            var response = new Response<List<GetCourseDTO>>();

            try
            {
                response.status = true;
                response.value = await _courseService.GetListCourse();
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
        public async Task<IActionResult> SaveCourse([FromBody] CreateCourseDTO course)
        {
            var response = new Response<GetCourseDTO>();

            try
            {
                response.status = true;
                response.value = await _courseService.CreateCourse(course);
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
        public async Task<IActionResult> EditCourse([FromBody] UpdateCourseDTO course)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _courseService.UpdateCourse(course);
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
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _courseService.EliminateCourse(id);
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