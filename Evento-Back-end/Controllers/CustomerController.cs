using Microsoft.AspNetCore.Mvc;
using Evento_Back_end.DomainModels;
using Evento_Back_end.DTOs;
using Evento_Back_end.Data;

namespace Evento_Back_end.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers
                .Select(s => new CustomerDTO
                {
                    CustomerID = s.CustomerID,
                    FirstName = s.FirstName,
                    LastName = s.LastName
                })
                .ToList();

        }
    }
}
