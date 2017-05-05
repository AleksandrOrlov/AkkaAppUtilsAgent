using System;
using System.Collections.Generic;
using System.Linq;
using UtilsAgent.Core.Interfaces;

namespace UtilsAgent.Core.Dto
{
    public class ValidationCommandResult : IValidationCommandResult
    {
        public IReadOnlyCollection<ValidationError> ValidationErrors => _errors;

        public bool HasError => _errors.Any();

        private readonly List<ValidationError> _errors;

        public ValidationCommandResult()
        {
            _errors = new List<ValidationError>();
        }

        public void AddError(ValidationError error)
        {
            _errors.Add(error);
        }
    }
}
