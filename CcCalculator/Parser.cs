namespace CcCalculator;

public class Parser(Token[] tokens)
{
    private Token[] Tokens { get; set; } = tokens;

    private int Position { get; set; } = 0;

    private Token? CurrentToken { get; set; } = null;

    public Expression Parse()
    {
        NextToken();
        Expression left = ParseExpression();

        NextToken();
        if (CurrentToken == null)
        {
            throw new Exception("Unexpected end of input");
        }
        char operation = CurrentToken.Literal;

        NextToken();
        Expression right = ParseExpression();

        return new BinaryExpression(left, right, operation);
    }

    private Expression ParseExpression()
    {
        if (CurrentToken == null)
        {
            throw new Exception("Unexpected end of input");
        }
        return CurrentToken.Type switch
        {
            TokenType.Number => new NumberExpression(char.GetNumericValue(CurrentToken.Literal)),
            _ => throw new Exception($"Unexpected token {CurrentToken}"),
        };
    }

    private void NextToken()
    {
        if (Position == Tokens.Length)
        {
            CurrentToken = null;
        }
        else
        {
            CurrentToken = Tokens[Position];
            Position++;
        }
    }
}
