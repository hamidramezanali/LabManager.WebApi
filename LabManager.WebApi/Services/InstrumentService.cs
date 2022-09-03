using LabManager.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LabManager.WebApi.Services
{
    public class InstrumentService
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
        public IEnumerable<Instrument> ListProducts()
        {
            return _repository.ListProducts();
        }
        public bool AddInstrument(Instrument instrumentToAdd)
        {
            // Validation logic
            if (!ValidateInstrument(instrumentToAdd))
                return false;

            // Database logic
            try
            {
                _repository.AddInstrument(instrumentToAdd);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool UpdateInstrument(Instrument instrumentToUpdate)
        {
            // Validation logic
            if (!ValidateInstrument(instrumentToUpdate))
                return false;

            // Database logic
            try
            {
                _repository.AddInstrument(instrumentToUpdate);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool UpdateInstrument(int id)
        {

            // Database logic
            try
            {
                _repository.DeleteInstrument(id);
            }
            catch
            {
                return false;
            }
            return true;
        }

    }

}
