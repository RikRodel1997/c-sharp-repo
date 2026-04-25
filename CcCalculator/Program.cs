namespace CcCalculator;

public class Program
{
    public static void Main(string[] args)
    {
        string input = args[0];
        Run(input);
    }

    public static double Run(string input)
    {
        Token[] tokens = new Lexer(input).Lex();
        Token[] prnTokens = new Parser(tokens).Parse();
        double evaluated = Evaluate(prnTokens);
        return evaluated;
    }

    private static double Evaluate(Token[] prnTokens)
    {
        Stack<double> stack = [];
        foreach (Token token in prnTokens)
        {
            if (token.Type == TokenType.Number)
            {
                stack.Push(int.Parse(token.Literal));
            }

            if (token.Type == TokenType.Function)
            {
                double top = stack.Pop();
                double result = token.Literal switch
                {
                    "sin" => Math.Sin(top),
                    "cos" => Math.Cos(top),
                    "tan" => Math.Tan(top),
                    _ => throw new Exception($"Unknown function: ${token.Literal}"),
                };
                stack.Push(result);
            }

            if (token.Type == TokenType.Operator)
            {
                double first = stack.Pop();
                double second = stack.Pop();

                double result = token.Literal switch
                {
                    "*" => second * first,
                    "-" => second - first,
                    "+" => second + first,
                    "/" => second / first,
                    _ => throw new Exception($"Unknown operator: {token.Literal}"),
                };

                stack.Push(result);
            }
        }
        return stack.Pop();
    }
}
