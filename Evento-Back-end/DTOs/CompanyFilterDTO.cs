namespace Evento_Back_end.DTOs
{
    public class CompanyFilterDTO
    {
        public string? SearchTerm { get; set; }
        public List<string>? Services { get; set; }
        public List<string>? Municipalities { get; set; }
    }
}
