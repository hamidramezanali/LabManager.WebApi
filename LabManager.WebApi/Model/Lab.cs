namespace LabManager.WebApi.Model

{
    public class Lab
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Guid> InstrumentIDs { get; set; }
    }
}
