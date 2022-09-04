namespace LabManager.WebApi.Model
{
    public class Instrument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid LabId { get; set; }
    }
}
