namespace DefectMapApplication.Models
{
    public class ServerFile
    {
        public Guid Id { get; init; }
        public string FileName { get; init; }
        public string StoredFileName { get; init; }
        public string ContentType { get; init; }
    }
}
