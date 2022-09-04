using LabManager.WebApi.Model;

namespace LabManager.WebApi.Repository
{
    public class InstrumentRepository : IInstrumentRepository
    {
        public async Task<bool> AddInstrument(Instrument instrumentToAdd)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteInstrument(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Instrument> GetInstrument(int id)
        {
            return await Task.FromResult(new Instrument() { Id = 2, Name = "MiSeq1", LabId = Guid.NewGuid() });
        }

        public async Task<IEnumerable<Instrument>> GetInstruments()
        {
            return await Task.FromResult(
             new List<Instrument>() {
             new Instrument() { Id = 2, Name = "MiSeq1", LabId =  Guid.NewGuid() },
            new Instrument() { Id = 3, Name = "MiSeq2", LabId = Guid.NewGuid() },
            new Instrument() { Id = 4, Name = "MiSeq3", LabId = Guid.NewGuid() }
           }
               );
        }

    }
}
