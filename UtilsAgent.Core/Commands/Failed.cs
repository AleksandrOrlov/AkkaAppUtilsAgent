namespace UtilsAgent.Core.Commands
{
    public class Failed
    {
        public string Message { get; }

        public Failed(string message)
        {
            Message = message;
        }
    }
}
