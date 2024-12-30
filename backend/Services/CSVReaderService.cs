using CsvHelper;
using CsvHelper.Configuration;

public class CSVReaderService : ICSVReaderService
{
    public async Task<List<FileInput>> ReadCSVFileAsync(string filePath)
    {
        var records = new List<FileInput>();

        try
        {
            var reader = new StreamReader(filePath);
            var csv = new CsvReader(reader, new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture) { HasHeaderRecord = true });
            csv.Context.RegisterClassMap<FileInputMap>();
            records = csv.GetRecords<FileInput>().ToList();

            await foreach (var record in csv.GetRecordsAsync<FileInput>())
            {
                records.Add(record);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }

        return records;
    }
}
