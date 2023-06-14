namespace JobBoard.Contracts.Authentication
{
    public record AuthenticationResponse(
        Guid Id,
        string CompanyName,
        string Email,
        string Token);

}