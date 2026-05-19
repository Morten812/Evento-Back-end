using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly AppDbContext _context;

        public RequestController(IRequestAsyncRepository requestRepository, AppDbContext context)
        {
            _requestRepository = requestRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<RequestDTO>>> GetRequests()
        {
            var requests = await _context.Requests
                .Select(r => new RequestDTO
                {
                    RequestID = r.RequestID,
                    ServiceID = r.ServiceID,
                    Description = r.Description,
                    Status = r.Status,
                    ServiceName = r.Service.Name,
                    CustomerName = r.Customer.FirstName + " " + r.Customer.LastName
                })
                .ToListAsync();

            return Ok(requests);
        }

        [HttpGet("service{serviceId}")]
        public async Task<ActionResult<List<RequestDTO>>> GetRequestsByService(int serviceId)
        {
            var requests = await _context.Requests
                .Where(r => r.ServiceID == serviceId)
                .Select(r => new RequestDTO
                {
                    RequestID = r.RequestID,
                    ServiceID = r.ServiceID,
                    Description = r.Description,
                    Status = r.Status
                })
                .ToListAsync();
            return Ok(requests);
        }

        [HttpGet("company/{companyId}")]
        public async Task<ActionResult<List<RequestDTO>>> GetRequestsByCompany(int companyId)
        {
            var requests = await _context.Requests
                .Where(r => r.CompanyID == companyId && r.Status == RequestStatus.Pending)
                .Select(r => new RequestDTO
                {
                    RequestID = r.RequestID,
                    ServiceID = r.ServiceID,
                    Description = r.Description,
                    Status = r.Status,
                    ServiceName = r.Service.Name,
                    CustomerName =
                        r.Customer.FirstName + " " +
                        r.Customer.LastName,

                    CreatedAt = r.CreatedAt
                })
                .ToListAsync();
            return Ok(requests);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest([FromBody] CreateRequestDTO dto)
        {
            var service = await _context.Services
                .FirstOrDefaultAsync(s => s.ServiceID == dto.ServiceID);

            if (service == null)
                return BadRequest("Service not found");

            var request = new Request
            {
                ServiceID = dto.ServiceID,
                CompanyID = service.CompanyID, // derives automatically from the service class
                CustomerID = dto.CustomerID,

                Description = dto.Description,

                Status = RequestStatus.Pending,

                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                RequestedStart = DateTime.UtcNow
            };

            await _requestRepository.AddAsync(request);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var request = await _requestRepository.GetByIdAsync(id);

            if (request == null)
                return NotFound();

            await _requestRepository.DeleteAsync(request);

            return NoContent();
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateRequestStatusDTO dto)
        {
            var request = await _context.Requests
                .FirstOrDefaultAsync(r => r.RequestID == id);

            if (request == null)
                return NotFound();

            request.Status = dto.Status;
            request.RespondedAt = DateTime.UtcNow;

            if (dto.Status == RequestStatus.Cancelled)
            {
                request.RequestedEnd = DateTime.UtcNow;
            }

            Console.WriteLine($"Saving status: {request.Status}");

            var result = await _context.SaveChangesAsync();

            Console.WriteLine($"Rows affected: {result}");

            return Ok(request.Status);
        }

        [HttpGet("jobs")]
        public async Task<ActionResult<List<RequestDTO>>> GetApprovedRequests()
        {
            var jobs = await _context.Requests
                .Where(r => r.Status == RequestStatus.Approved)
                .Select(r => new RequestDTO
                {
                    RequestID = r.RequestID,
                    ServiceID = r.ServiceID,
                    Description = r.Description,
                    Status = r.Status,
                    ServiceName = r.Service.Name,
                    CustomerName = r.Customer.FirstName + " " + r.Customer.LastName,
                    RespondedAt = r.RespondedAt
                })
                .ToListAsync();

            return Ok(jobs);
        }
    }
}
