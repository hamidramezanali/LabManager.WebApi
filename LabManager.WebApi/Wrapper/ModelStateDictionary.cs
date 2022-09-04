using LabManager.WebApi.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LabManager.WebApi.Wrapper
{
    public class ModelStateWrapper : IValidationDictionary
    {

        private ModelStateDictionary _modelState;

        public ModelStateWrapper()
        {
            _modelState = new ModelStateDictionary();
        }

        #region IValidationDictionary Members

        public void AddError(string key, string errorMessage)
        {
            _modelState.AddModelError(key, errorMessage);
        }

        public bool IsValid
        {
            get { return _modelState.IsValid; }
        }

        #endregion
    }
}
