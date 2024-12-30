public interface ICSVReaderService
{
    Task<List<FileInput>> ReadCSVFileAsync(string filePath);
}
