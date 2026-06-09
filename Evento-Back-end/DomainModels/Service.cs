using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evento_Back_end.DomainModels
{
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }
        public int CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public Company Company { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public enum HiringType { Manual = 1, Online = 2 };
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? DurationMinutes { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<Request> Requests { get; set; }
    }

    public enum ServiceCategory
    {
        Cleaning = 1,
        Security = 2,
        Transportation = 3
    }
}
