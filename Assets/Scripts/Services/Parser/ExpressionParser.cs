namespace Services.Parser
{
    public class ExpressionParser : IExpressionParser
    {
        public bool TryGetResult(string input, out int result)
        {
            result = 0;
            
            if (!input.Contains("+")) return false;

            string[] results = input.Split("+");
            
            if (results.Length != 2) return false;

            if (!int.TryParse(results[0], out int first) || first < 0) return false;
            if (!int.TryParse(results[1], out int second) || second < 0) return false;

            result = first + second;
            return true;
        }
    }
}