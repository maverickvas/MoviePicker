using Google.Apis.Sheets.v4.Data;

namespace MoviePicker.Services.Interfaces
{
    public interface IGoogelSpreadsheetManager
    {
        Spreadsheet GetSpreadsheet(string spreadsheetIdentifier);
        ValueRange GetValue(string spreadsheetIdentifier, string cell);
        BatchGetValuesResponse GetValueRange(string spreadsheetIdentifier, string[] range);
        void RemoveValue(string spreadsheetIdentifier, string cell);
        void RemoveRow(string spreadsheetIdentifier, int cell);
    }
}
