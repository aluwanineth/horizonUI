using HorizonPollyC.Models;

namespace HorizonPollyC.Services.Authentication
{
    public interface IAuthenticationService
    {
        User User { get; set; }
        AuthResult authResult { get; }
        Task Initialize();
        Task Login(User user);
        Task Logout();
        Task RefreshToken(AuthResult authResult);
    }

}
