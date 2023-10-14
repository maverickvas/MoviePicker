using Google.Apis.Auth.OAuth2;

namespace MoviePicker.Services.Interfaces
{
    public interface ILoginService
    {
        UserCredential Login();
    }
}
