namespace Typeform.Dotnet.Data
{
    public class AnswerChoice : Answer
    {
        public Choice Choice { get; set; }
        public override string GetValue()
        {
            return Choice.Label;
        }
    }
}