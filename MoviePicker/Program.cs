using MoviePicker.Services;

namespace MoviePicker
{
    public class Program
    {
        static void Main()
        {
            var processingService = new ProcessingService();
            var loginService = new LoginService();

            var creds = loginService.Login();
            var response = processingService.PickMovie(creds);
            if (response.Confirmed)
            {
                processingService.RemoveMovieFromSheet(creds, response.Index);
            }
        }
    }
}