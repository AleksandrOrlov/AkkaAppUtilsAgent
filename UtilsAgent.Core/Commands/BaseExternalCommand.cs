using System.Collections.Generic;
using System.Linq;
using UtilsAgent.Core.Dto;
using UtilsAgent.Core.Extensions;
using UtilsAgent.Core.Interfaces;

namespace UtilsAgent.Core.Commands
{
    public abstract class BaseExternalCommand : IValidatedCommand
    {
        private IEnumerable<Argument> Args { get; }

        protected BaseExternalCommand()
        {
        }

        protected BaseExternalCommand(ExternalRequest request)
        {
            Args = request.Args ?? Enumerable.Empty<Argument>();
        }

        protected T GetValue<T>(string key)
        {
            return Args.Where(a => a.Key == key).Select(a => a.Value.ChangeType<T>()).FirstOrDefault();
        }

        protected IEnumerable<T> GetAllValues<T>(string key)
        {
            return Args.Where(a => a.Key == key).Select(a => a.Value.ChangeType<T>());
        }

        public bool IsValid
        {
            get
            {
                var validationResult = Validate();
                return !validationResult.HasError;
            }
        }

        public abstract IValidationCommandResult Validate();
    }
}
