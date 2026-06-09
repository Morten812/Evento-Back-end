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
        public IEnumerable<CompanyDTO> GetCompanies(string? searchTerm, List<string>? categories)
        {
            var query = _context.Companies.AsQueryable();

            if(!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(c => c.Name.Contains(searchTerm));
            }

            if (categories != null && categories.Any())
            {
                query = query.Where(c =>
                _context.Services.Any(s =>
                    s.CompanyID == c.CompanyID &&
                    categories.Contains(s.Type)
                    )
                );
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
