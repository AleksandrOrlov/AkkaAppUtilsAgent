using System.Collections.Generic;
using System.Linq;
using UtilsAgent.Core.Dto;

namespace UtilsAgent.Core.Commands
{
    public abstract class BaseExternalCommand
    {
        private IEnumerable<Arguments> Args { get; }

        protected BaseExternalCommand(ExternalRequest request)
        {
            Args = request.Args ?? Enumerable.Empty<Arguments>();
        }

        protected T GetSingle<T>(string key) where T : class
        {
            return Args.Where(a => a.Key == key).Select(a => a.Value).FirstOrDefault();
        }
    }
}
