using Google.Apis.Auth.OAuth2;
using MoviePicker.Services.Interfaces;
using System.Configuration;

namespace MoviePicker.Services
{
    public class LoginService : ILoginService
    {
        public UserCredential Login()
        {
            var clientId = ConfigurationManager.AppSettings["clientId"];
            var secret = ConfigurationManager.AppSettings["secret"];
            string[] scope = new[] { Google.Apis.Sheets.v4.SheetsService.Scope.Spreadsheets };

            ClientSecrets secrets = new()
            {
                ClientId = clientId,
                ClientSecret = secret
            };
            try
            {
                return GoogleWebAuthorizationBroker.AuthorizeAsync(secrets, scope, "user", CancellationToken.None).Result;
            }
            catch (Exception)
            {
                Console.WriteLine("Login failed");
                throw;
            }
        }
    }
}
