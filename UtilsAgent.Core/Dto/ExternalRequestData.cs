using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace UtilsAgent.Core.Dto
{
    [Serializable]
    public class ExternalRequestData
    {
        public string Command { get; set; }

        [XmlArrayItem("Item")]
        public List<Argument> Args { get; set; }

        public ExternalRequestData() { }
    }
}
