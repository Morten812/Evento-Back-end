using Microsoft.EntityFrameworkCore;
using Evento_Back_end.Data;

namespace Evento_Back_end.Facades
{
    public class CompanyFacade
    {
        private readonly AppDbContext _context;

        public CompanyFacade(AppDbContext context)
        {
            _context = context;
        }
    }
}
