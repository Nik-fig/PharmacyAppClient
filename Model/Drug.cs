namespace PharmacyAppClient.Models
{
    public class Drug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Group Group { get; set; }
        public Provider Provider { get; set; }
    }
}
