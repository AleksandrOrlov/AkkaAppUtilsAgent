using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilsAgent.Core.Dto
{
    internal class ExternalCommandItem
    {
        public string CommandText { get; set; }

        public Type ActorType { get; set; }

        public Type CommandType { get; set; }
    }
}
