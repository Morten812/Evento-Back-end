using Microsoft.AspNetCore.Mvc;
using Evento_Back_end.DomainModels;
using Evento_Back_end.DTOs;
using Evento_Back_end.Data;
using Evento_Back_end.Contracts;

namespace Evento_Back_end.Controllers
{
    [ApiController]
    [Route("api/requests")]
    public class RequestController : ControllerBase
    {
        private readonly IRequestAsyncRepository _requestRepository;

        public RequestController(IRequestAsyncRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest([FromBody] Request request)
        {
            await _requestRepository.AddAsync(request);
            return Ok();
        }

        [HttpGet("service/serviceId")]
        public async Task<ActionResult<IList<Request>>> GetByService(int serviceId)
        {
            var requests = await _requestRepository.GetByServiceIdAsync(serviceId);
            return Ok(requests);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var request = await _requestRepository.GetByIdAsync(id);

        }
    }
}
