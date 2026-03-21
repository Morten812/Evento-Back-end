namespace Evento_Back_end.DomainModels
{
    public class Company
    {

        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }
        public string? Industry { get; set; }
        public string? Web { get; set; }
        public bool IsActive { get; set; }
        public bool IsPublic { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

    }
}
