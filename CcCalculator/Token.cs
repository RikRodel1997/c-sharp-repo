namespace CcCalculator;

public enum TokenType
{
    Number,
    Star,
    Minus,
    Plus,
    Divide,
}

public class Token(TokenType type, char literal)
{
    public TokenType Type { get; } = type;

    public char Literal { get; } = literal;
}
