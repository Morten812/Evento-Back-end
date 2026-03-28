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
                    CompanyId = c.CompanyId,
                    Name = c.Name
                })
                .ToList();

        }
    }
}
