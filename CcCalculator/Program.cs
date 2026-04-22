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
        Token[] tokens = Lexer.Lex(input);
        Expression expression = new Parser(tokens).Parse();

        return Evaluate(expression);
    }

    private static double Evaluate(Expression expression)
    {
        if (expression is BinaryExpression binary)
        {
            NumberExpression left = (NumberExpression)binary.Left;
            NumberExpression right = (NumberExpression)binary.Right;

            return binary.Op switch
            {
                '*' => left.Value * right.Value,
                '-' => left.Value - right.Value,
                '+' => left.Value + right.Value,
                '/' => left.Value / right.Value,
                _ => throw new Exception($"Invalid operator {binary.Op}"),
            };
        }
        throw new Exception($"Invalid expression to evaluate {expression}");
    }
}
