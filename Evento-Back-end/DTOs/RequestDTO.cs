using Evento_Back_end.DomainModels;
using static Evento_Back_end.DomainModels.Request;

namespace Evento_Back_end.DTOs
{
    public class RequestDTO
    {
        public int RequestID { get; set; }
        public int ServiceID { get; set; }
        public int CompanyID { get; set; }
        public int CustomerID { get; set; }
        public string Description { get; set; }
        public RequestStatus Status { get; set; }
        public string ServiceName { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? RespondedAt { get; set; }

    }
}
