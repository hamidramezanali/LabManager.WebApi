using LabManager.Models;

namespace LabManager.WebApi.Services
{
    public interface IInstrumentRepository
    {
        IEnumerable<Instrument> ListProducts();
        void AddInstrument(Instrument instrumentToAdd);
        void DeleteInstrument(int id);
    }
}