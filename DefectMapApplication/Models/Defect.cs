namespace DefectMapApplication.Models
{
    public class Defect
    {
        public int Id { get; init; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<ServerFile> Photos { get; set; }

        public User Owner { get; init; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double HorizontalAccuracy { get; set; }
        public double VerticalAccuracy { get; set; }
    }
}
