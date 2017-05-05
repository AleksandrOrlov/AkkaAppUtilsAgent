using System.Collections.Generic;
using UtilsAgent.Core.Dto;

namespace UtilsAgent.Core.Interfaces
{
    public interface IValidationCommandResult
    {
        bool HasError { get; }

        IReadOnlyCollection<ValidationError> ValidationErrors { get; }
    }
}
