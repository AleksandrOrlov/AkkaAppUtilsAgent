using UtilsAgent.Core.Dto;

namespace UtilsAgent.Core.Interfaces
{
    public interface IValidatedCommand
    {
        IValidationCommandResult Validate();

        bool IsValid { get; }
    }
}
