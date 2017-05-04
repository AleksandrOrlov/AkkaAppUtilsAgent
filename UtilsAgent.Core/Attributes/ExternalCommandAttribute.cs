using System;

namespace UtilsAgent.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExternalCommandAttribute : Attribute
    {
        public Type ActorType { get; }

        public string CommandText { get; }

        public ExternalCommandAttribute(string commandText, Type actorType)
        {
            ActorType = actorType;
            CommandText = commandText;
        }
    }
}
