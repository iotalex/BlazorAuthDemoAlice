namespace BlazorAuthDemo.Services
{
    public interface IAuthenticationService
    {
        bool Authenticate(string username, string password);
        bool IsAuthenticated { get; }
    }
}
