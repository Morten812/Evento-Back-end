using Evento_Back_end.DomainModels;
using static Evento_Back_end.DomainModels.Request;

namespace Evento_Back_end.DTOs
{
    public class CreateRequestDTO
    {
        public int ServiceID { get; set; }
        public string? Description { get; set; }
    }
}
