namespace JobBoard.Application.Services.Authentication
{
    public record AuthenticationResult(
        Guid Id,
        string CompanyName,
        string Email,
        string Token);
}
