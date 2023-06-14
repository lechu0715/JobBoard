namespace JobBoard.Contracts.Authentication
{
    public record RegisterRequest(
        string CompanyName,
        string Email,
        string Password);

}