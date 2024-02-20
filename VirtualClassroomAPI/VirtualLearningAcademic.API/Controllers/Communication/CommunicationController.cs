using Microsoft.AspNetCore.Mvc;
using VirtualLearningAcademic.API.Utility;
using VirtualLearningAcademic.BLL.Services.Contracts.Communication;
using VirtualLearningAcademic.DTO.Communication;

namespace VirtualLearningAcademic.API.Controllers.Communication
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationController : ControllerBase
    {
        private readonly ICommunicationService _communicationService;
        public CommunicationController(ICommunicationService communicationService)
        {
            _communicationService = communicationService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetCommunication()
        {
            var response = new Response<List<GetCommunicationDTO>>();

            try
            {
                response.status = true;
                response.value = await _communicationService.GetListCommunication();
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
        public async Task<IActionResult> SaveCommunication([FromBody] CreateCommunicationDTO communication)
        {
            var response = new Response<GetCommunicationDTO>();

            try
            {
                response.status = true;
                response.value = await _communicationService.CreateCommunication(communication);
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
        public async Task<IActionResult> EditCommunication([FromBody] UpdateCommunicationDTO communication)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _communicationService.UpdateCommunication(communication);
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
        public async Task<IActionResult> DeleteCommunication(int id)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _communicationService.EliminateCommunication(id);
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