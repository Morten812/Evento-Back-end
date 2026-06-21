namespace Evento_Back_end.DomainModels
{
    public class Member
    {
        public int MemberID { get; set; }
        public int CompanyID { get; set; }
        public string UserID { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public enum MemberRole
    {
        Subordinate,
        Manager
    }
}
