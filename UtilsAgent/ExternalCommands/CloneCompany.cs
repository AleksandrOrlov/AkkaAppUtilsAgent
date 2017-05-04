using UtilsAgent.CompanyCloning;
using UtilsAgent.Core.Attributes;
using UtilsAgent.Core.Commands;

namespace UtilsAgent.ExternalCommands
{
    [ExternalCommand("clone-company", typeof(TestMsgActor))]
    public class CloneCompany : BaseExternalCommand
    {
        public CloneCompany(ExternalRequest request)
            : base(request)
        {
            //To Do Parse Args
            CompanyId = "asf";
        }

        public string CompanyId { get; }
    }
}
