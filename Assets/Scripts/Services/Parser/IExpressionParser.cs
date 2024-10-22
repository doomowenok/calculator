namespace Services.Parser
{
    public interface IExpressionParser
    {
        bool TryGetResult(string input, out int result);
    }
}