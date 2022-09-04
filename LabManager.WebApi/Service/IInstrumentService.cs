using LabManager.WebApi.Model;

namespace LabManager.WebApi.Service
{
    public interface IInstrumentService
    {
        Task<Instrument> GetInstrument(int id);
        Task<IEnumerable<Instrument>> GetInstruments();
        Task<bool> AddInstrument(Instrument instrumentToAdd);

        Task<bool> UpdateInstrument(Instrument instrumentToUpdate);
  
    }
}