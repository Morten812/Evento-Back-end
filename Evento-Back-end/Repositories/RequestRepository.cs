using Microsoft.EntityFrameworkCore;
using Evento_Back_end.Contracts;
using Evento_Back_end.DomainModels;
using Evento_Back_end.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evento_Back_end.Repositories
{
    public class RequestRepository : BaseAsyncRepository<Request>, IRequestAsyncRepository
    {
        public RequestRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task<IList<Request>> GetByServiceIdAsync(int serviceId)
        {
            return await context.Requests
                .Where(s => s.ServiceID == serviceId)
                .ToListAsync();
        }

        public async Task<IList<Request>> SearchByDescriptionAsync(string searchTerm)
        {
            return await context.Requests
                .Where(d => d.Description == searchTerm)
                .ToListAsync();
        }
    }
}
