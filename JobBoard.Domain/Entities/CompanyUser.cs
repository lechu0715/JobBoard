namespace JobBoard.Domain.Entities
{
    public class CompanyUser
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CompanyName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
