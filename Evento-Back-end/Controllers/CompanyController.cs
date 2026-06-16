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
        public IEnumerable<CompanyDTO> GetCompanies([FromQuery] CompanyFilterDTO filter)
        {
            var query = _context.Companies.AsQueryable();

            if(!string.IsNullOrWhiteSpace(filter.SearchTerm))
            {
                query = query.Where(c => c.Name.Contains(filter.SearchTerm));
            }

            if (filter.Services != null && filter.Services.Any())
            {
                query = query.Where(c =>
                _context.Services.Any(s =>
                    s.CompanyID == c.CompanyID &&
                    filter.Services.Contains(s.Type)
                    )
                );
            }
            
            if (filter.Municipalities != null && filter.Municipalities.Any())
            {
                query = query.Where(c =>
                    filter.Municipalities.Contains(c.Municipality));
            }
            
            return query
                .Select(c => new CompanyDTO
                {
                    CompanyID = c.CompanyID,
                    Name = c.Name,
                    Description = c.Description,
                    Email = c.Email,
                    LogoUrl = c.LogoUrl,
                    Municipality = c.Municipality,
                    Region = c.Region
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
                    Name = s.Name,
                    Description = s.Description,
                    Price = s.Price
                })
                .ToList();
        }

        [HttpGet("service-types")]
        public IEnumerable<string> GetServiceTypes()
        {
            return _context.Services
                .Select(s => s.Type)
                .Distinct()
                .OrderBy(t => t)
                .ToList();
        }

        [HttpGet("{companyId}")]
        public ActionResult<CompanyDTO> GetCompany(int companyId)
        {
            var company = _context.Companies
                .Where(c => c.CompanyID == companyId)
                .Select(c => new CompanyDTO
                {
                    CompanyID = c.CompanyID,
                    Name = c.Name,
                    Description = c.Description,
                    LogoUrl = c.LogoUrl
                })
                .FirstOrDefault(c => c.CompanyID == companyId);

            if (company == null)
                return NotFound();

            return Ok(company);
        }
    }
}
