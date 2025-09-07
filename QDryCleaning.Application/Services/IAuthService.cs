namespace QDryClean.Application.Services
{
    public interface IAuthService 
    {
        Task<string> LoginAsync(string login, string password);
    }
}
