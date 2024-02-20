using Microsoft.AspNetCore.Mvc;
using VirtualLearningAcademic.API.Utility;
using VirtualLearningAcademic.BLL.Services.Contracts.StudentEnrollment;
using VirtualLearningAcademic.DTO.StudentEnrollment;

namespace VirtualLearningAcademic.API.Controllers.Enrollment
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentEnrollmentController : ControllerBase
    {
        private readonly IStudentEnrollmentService _enrollmentService;
        public StudentEnrollmentController(IStudentEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetEnrollment()
        {
            var response = new Response<List<GetStudentEnrollmentDTO>>();

            try
            {
                response.status = true;
                response.value = await _enrollmentService.GetListEnrollment();
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
        public async Task<IActionResult> SaveEnrollment([FromBody] CreateStudentEnrollmentDTO enrollment)
        {
            var response = new Response<GetStudentEnrollmentDTO>();

            try
            {
                response.status = true;
                response.value = await _enrollmentService.CreateEnrollment(enrollment);
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
        public async Task<IActionResult> EditEnrollment([FromBody] UpdateStudentEnrollmentDTO enrollment)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _enrollmentService.UpdateEnrollment(enrollment);
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
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _enrollmentService.EliminateEnrollment(id);
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