using Evento_Back_end.DomainModels;

namespace Evento_Back_end.Contracts
{
    public interface IRequestAsyncRepository : IAsyncRepository<Request>
    {
        Task<IList<Request>> GetByServiceIdAsync(int serviceId);
        Task<IList<Request>> SearchByDescriptionAsync(string searchTerm);
    }
}
