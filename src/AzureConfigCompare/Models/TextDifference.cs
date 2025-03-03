namespace AzureConfigCompare.Models
{
    public class TextDifference
    {
        public TextDifference(int lineNumber, string message)
        {
            LineNumber = lineNumber;
            Message = message;
        } 

        public int LineNumber { get; set; }
        public string Message { get; set; }
    }
}
