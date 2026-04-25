namespace CcCalculator;

public class Lexer(string input)
{
    private readonly string Input = input;

    private int Pos = 0;

    public Token[] Lex()
    {
        List<Token> tokens = [];

        while (Pos < Input.Length)
        {
            char c = Input[Pos];
            if (char.IsWhiteSpace(c))
            {
                Pos++;
                continue;
            }

            if (char.IsNumber(c))
            {
                int numberStart = Pos;
                while (Pos < Input.Length && char.IsNumber(Input[Pos]))
                {
                    Pos++;
                }
                tokens.Add(new Token(TokenType.Number, Input[numberStart..Pos]));
                continue;
            }

            if (char.IsLetter(c))
            {
                int functionStart = Pos;
                while (Pos < Input.Length && char.IsLetter(Input[Pos]))
                {
                    Pos++;
                }
                tokens.Add(new Token(TokenType.Function, Input[functionStart..Pos]));
                continue;
            }

            Token token = c switch
            {
                '*' => new Token(TokenType.Operator, c.ToString()),
                '-' => new Token(TokenType.Operator, c.ToString()),
                '+' => new Token(TokenType.Operator, c.ToString()),
                '/' => new Token(TokenType.Operator, c.ToString()),
                '(' => new Token(TokenType.LParen, c.ToString()),
                ')' => new Token(TokenType.RParen, c.ToString()),
                _ => throw new Exception($"Invalid character: {c}"),
            };
            tokens.Add(token);

            Pos++;
        }

        return [.. tokens];
    }
}
