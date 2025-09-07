namespace QDryClean.Application.Services.JWTServices
{
    public interface IAuthService 
    {
        Task<string> LoginAsync(string login, string password);
    }
}
