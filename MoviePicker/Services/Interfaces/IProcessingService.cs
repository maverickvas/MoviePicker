using Google.Apis.Auth.OAuth2;
using MoviePicker.DTO;

namespace MoviePicker.Services.Interfaces
{
    public interface IProcessingService
    {
        MovieChoice PickMovie(UserCredential userCredential);
        bool RemoveMovieFromSheet(UserCredential userCredential, int index);
    }
}
