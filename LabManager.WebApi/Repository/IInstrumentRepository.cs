using LabManager.WebApi.Model;

namespace LabManager.WebApi.Repository
{
    public interface IInstrumentRepository
    {
        Task<IEnumerable<Instrument>> GetInstruments();
        Task<Instrument> GetInstrument(int id);
        Task<bool> AddInstrument(Instrument instrumentToAdd);
        Task<bool> DeleteInstrument(int id);
    }
}