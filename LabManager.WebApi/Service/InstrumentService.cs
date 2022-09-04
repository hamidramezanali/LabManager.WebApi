using LabManager.WebApi.Model;
using LabManager.WebApi.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LabManager.WebApi.Service
{
    public class InstrumentService : IInstrumentService
    {

        private ModelStateDictionary _modelState;
        private IInstrumentRepository _repository;

        private IValidationDictionary _validatonDictionary;
        public InstrumentService(IValidationDictionary validationDictionary, IInstrumentRepository repository)
        {
            _validatonDictionary = validationDictionary;
            _repository = repository;
        }

        protected bool ValidateInstrument(Instrument instrumentToValidate)
        {
            //if (productToValidate.Name.Trim().Length == 0)
            //    _modelState.AddModelError("Name", "Name is required.");
            //if (productToValidate.Description.Trim().Length == 0)
            //    _modelState.AddModelError("Description", "Description is required.");
            //if (productToValidate.UnitsInStock < 0)
            //    _modelState.AddModelError("UnitsInStock", "Units in stock cannot be less than zero.");
            return _modelState.IsValid;
        }
        public async Task<IEnumerable<Instrument>> GetInstruments()
        {
            return await _repository.GetInstruments();           
        }

        public async Task<Instrument> GetInstrument(int id)
        {
            return await _repository.GetInstrument(id);
        }
        public Task<bool> AddInstrument(Instrument instrumentToAdd)
        {
            // Validation logic
            if (!ValidateInstrument(instrumentToAdd))
                 return Task.FromResult(false); 

            // Database logic
            try
            {
              return  _repository.AddInstrument(instrumentToAdd);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }
        public Task<bool> UpdateInstrument(Instrument instrumentToUpdate)
        {
            // Validation logic
            if (!ValidateInstrument(instrumentToUpdate))
                return Task.FromResult(false);

            // Database logic
            try
            {
              return _repository.AddInstrument(instrumentToUpdate);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }


 
    }

}
