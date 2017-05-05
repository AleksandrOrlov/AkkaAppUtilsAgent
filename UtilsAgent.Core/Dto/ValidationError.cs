namespace UtilsAgent.Core.Dto
{
    public class ValidationError
    {
        public string Message { get; set; }
        
        public static ValidationError NullProperty(string name)
        {
            return new ValidationError {Message = $"{name} is null"};
        }
    }
}
