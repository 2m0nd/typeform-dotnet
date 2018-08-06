namespace Typeform.Dotnet.Data
{
    public class AnswerLongText : Answer
    {
        public string Text { get; set; }
        public override string GetValue()
        {
            return Text;
        }
    }
}