namespace CcCalculator;

public enum TokenType
{
    Operator,
    Number,
    LParen,
    RParen,
    Function,
}

public class Token(TokenType type, string literal)
{
    public TokenType Type { get; } = type;

    public string Literal { get; } = literal;
}
