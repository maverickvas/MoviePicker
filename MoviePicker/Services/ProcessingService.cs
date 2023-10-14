using Google.Apis.Auth.OAuth2;
using MoviePicker.DTO;
using MoviePicker.Helpers;
using MoviePicker.Services.Interfaces;
using System.Configuration;
using System.Diagnostics;

namespace MoviePicker.Services
{
    public class ProcessingService : IProcessingService
    {
        public MovieChoice PickMovie(UserCredential userCredential)
        {

            var spreadSheetId = ConfigurationManager.AppSettings.Get("spreadSheetId");
            var result = new MovieChoice();
            GoogleSpreadsheetManager manager = new(userCredential);
            var sheetData = manager.GetValue(spreadSheetId, "A2:A100");
            var data = sheetData.Values.SelectMany(a => a).ToList();

            var index = 0;
            var input = "";
            do
            {
                AnimationService.RollingAnimation(data);
                Console.Clear();
                index = Helper.GenerateRandomNumber(data.Count);
                Helper.AnimatedPrint(data[index].ToString(), colour: ConsoleColor.Green);
                Helper.AnimatedPrint("Reroll? y/n");
                input = Console.In.ReadLine();
            }
            while (input == "y");
            if (input == "n")
            {
                result.Index = index + 1;

                Helper.AnimatedPrint("Press 'y' to confirm OR 'n' to exit.");
                input = Console.In.ReadLine();
                if (input == "y")
                {
                    result.Confirmed = true;
                }
                else
                {
                    result.Confirmed = false;
                }
            }
            return result;
        }

        public bool RemoveMovieFromSheet(UserCredential userCredential, int index)
        {
            var spreadSheetId = ConfigurationManager.AppSettings.Get("spreadSheetId");
            GoogleSpreadsheetManager manager = new(userCredential);
            manager.RemoveRow(spreadSheetId, index);
            return true;
        }
    }
}