﻿namespace LabManager.WebApi.Services
{
    public interface IValidationDictionary
    {
        void AddError(string key, string errorMessage);
        bool IsValid { get; }
    }








}
