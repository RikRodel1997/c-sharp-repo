namespace CcCalculator;

public class Lexer
{
    public static Token[] Lex(string expression)
    {
        List<Token> tokens = [];
        foreach (char c in expression)
        {
            if (char.IsWhiteSpace(c))
            {
                continue;
            }
            if (char.IsNumber(c))
            {
                tokens.Add(new Token(TokenType.Number, c));
                continue;
            }

            Token token = c switch
            {
                '*' => new Token(TokenType.Star, c),
                '-' => new Token(TokenType.Minus, c),
                '+' => new Token(TokenType.Plus, c),
                '/' => new Token(TokenType.Divide, c),
                _ => throw new Exception($"Invalid character: {c}"),
            };
            tokens.Add(token);
        }

        return [.. tokens];
    }
}
