using Evento_Back_end.DomainModels;
using static Evento_Back_end.DomainModels.Request;

namespace Evento_Back_end.DTOs
{
    public class UpdateRequestStatusDTO
    {
        public RequestStatus Status { get; set; }
    }
}
