namespace CcCalculator;

public class Lexer(string input)
{
    private readonly string Input = input;

    public Token[] Lex()
    {
        List<Token> tokens = [];
        foreach (char c in Input)
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
                '*' => new Token(TokenType.Operator, c),
                '-' => new Token(TokenType.Operator, c),
                '+' => new Token(TokenType.Operator, c),
                '/' => new Token(TokenType.Operator, c),
                '(' => new Token(TokenType.LParen, c),
                ')' => new Token(TokenType.RParen, c),
                _ => throw new Exception($"Invalid character: {c}"),
            };
            tokens.Add(token);
        }

        return [.. tokens];
    }
}
