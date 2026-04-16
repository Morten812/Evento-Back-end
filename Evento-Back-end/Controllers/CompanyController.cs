using Microsoft.AspNetCore.Mvc;
using Evento_Back_end.DomainModels;
using Evento_Back_end.DTOs;
using Evento_Back_end.Data;

namespace Evento_Back_end.Controllers
{

    [ApiController]
    [Route("api/companies")]
    public class CompanyController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public CompanyController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<CompanyDTO> GetCompanies()
        {
            return _context.Companies
                .Select(c => new CompanyDTO
                {
                    CompanyID = c.CompanyID,
                    Name = c.Name,
                    Description = c.Description,
                    Email = c.Email
                })
                .ToList();

        }

        [HttpGet("{companyId}/services")]
        public IEnumerable<ServiceDTO> GetServicesForCompany(int companyId)
        {
            return _context.Services
                .Where(s => s.CompanyID == companyId)
                .Select(s => new ServiceDTO
                {
                    ServiceID = s.ServiceID,
                    Name = s.Name
                })
                .ToList();
        }
    }
}
