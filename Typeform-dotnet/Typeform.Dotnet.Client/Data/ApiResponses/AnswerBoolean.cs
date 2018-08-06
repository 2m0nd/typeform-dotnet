namespace Typeform.Dotnet.Data
{
    public class AnswerBoolean : Answer
    {
        public bool Boolean { get; set; }
        public override string GetValue()
        {
            return Boolean.ToString();
        }
    }
}