using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using MoviePicker.Services.Interfaces;

namespace MoviePicker.Services
{
    public class GoogleSpreadsheetManager : IGoogelSpreadsheetManager
    {
        private readonly UserCredential _credential;

        public GoogleSpreadsheetManager(UserCredential credential)
        {
            _credential = credential;
        }
        public Spreadsheet GetSpreadsheet(string spreadsheetIdentifier)
        {
            using var sheetService = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = _credential
            });
            return sheetService.Spreadsheets.Get(spreadsheetIdentifier).Execute();
        }

        public ValueRange GetValue(string spreadsheetIdentifier, string cell)
        {
            using var sheetService = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = _credential
            });
            return sheetService.Spreadsheets.Values.Get(spreadsheetIdentifier, cell).Execute();
        }

        public BatchGetValuesResponse GetValueRange(string spreadsheetIdentifier, string[] range)
        {
            using var sheetService = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = _credential
            });
            var request = sheetService.Spreadsheets.Values.BatchGet(spreadsheetIdentifier);
            return request.Execute();
        }

        public void RemoveValue(string spreadsheetIdentifier, string cell)
        {
            using var sheetService = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = _credential
            });
            sheetService.Spreadsheets.Values.Clear(new ClearValuesRequest(), spreadsheetIdentifier, cell).Execute();
        }

        public void RemoveRow(string spreadsheetIdentifier, int cell)
        {
            using var sheetService = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = _credential
            });

            Request body = new()
            {
                DeleteDimension = new DeleteDimensionRequest
                {
                    Range = new DimensionRange
                    {
                        SheetId = 0,
                        Dimension = "ROWS",
                        StartIndex = cell,
                        EndIndex = cell + 1
                    }
                }
            };
            BatchUpdateSpreadsheetRequest request = new()
            {
                Requests = new[] { body }
            };

            try
            {
                SpreadsheetsResource.BatchUpdateRequest Deletion = new(sheetService, request, spreadsheetIdentifier);
                Deletion.Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
