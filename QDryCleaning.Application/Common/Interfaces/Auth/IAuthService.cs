namespace QDryClean.Application.Common.Interfaces.Auth
{
    public interface IAuthService 
    {
        Task<string> LoginAsync(string login, string password);
    }
}
