namespace CcCalculator;

public enum TokenType
{
    Operator,
    Number,
    LParen,
    RParen,
}

public class Token(TokenType type, char literal)
{
    public TokenType Type { get; } = type;

    public char Literal { get; } = literal;
}
