namespace CcCalculator;

public class Program
{
    public static void Main(string[] args)
    {
        string input = args[0];
        Run(input);
    }

    public static int Run(string input)
    {
        Token[] tokens = new Lexer(input).Lex();
        Token[] prnTokens = new Parser(tokens).Parse();

        int evaluated = Evaluate(prnTokens);
        return evaluated;
    }

    private static int Evaluate(Token[] prnTokens)
    {
        Stack<int> stack = [];
        foreach (Token token in prnTokens)
        {
            if (token.Type == TokenType.Number)
            {
                stack.Push(token.Literal - '0');
            }

            if (token.Type == TokenType.Operator)
            {
                int first = stack.Pop();
                int second = stack.Pop();

                int result = token.Literal switch
                {
                    '*' => second * first,
                    '-' => second - first,
                    '+' => second + first,
                    '/' => second / first,
                    _ => throw new Exception($"Unknown operator: {token.Literal}"),
                };

                stack.Push(result);
            }
        }
        return stack.Pop();
    }
}
