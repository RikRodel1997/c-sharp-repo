namespace CcCalculator;

public class Parser(Token[] tokens)
{
    private static readonly Dictionary<char, int> Precedence = new()
    {
        { '(', 0 },
        { ')', 0 },
        { '-', 1 },
        { '+', 1 },
        { '*', 2 },
        { '/', 2 },
    };

    private Token[] Tokens { get; set; } = tokens;

    private readonly List<Token> OperatorQueue = [];

    private readonly List<Token> OutputQueue = [];

    public Token[] Parse()
    {
        foreach (var token in Tokens)
        {
            TokenType type = token.Type;

            switch (type)
            {
                case TokenType.Number:
                    OutputQueue.Add(token);
                    break;
                case TokenType.LParen:
                    OperatorQueue.Add(token);
                    break;
                case TokenType.RParen:
                    while (OperatorQueue.Count > 0 && OperatorQueue.Last().Type != TokenType.LParen)
                    {
                        OutputQueue.Add(OperatorQueue.Last());
                        OperatorQueue.RemoveAt(OperatorQueue.Count - 1);
                    }
                    if (OperatorQueue.Count > 0)
                    {
                        OperatorQueue.RemoveAt(OperatorQueue.Count - 1);
                    }
                    break;
                default:
                    if (OperatorQueue.Count == 0)
                    {
                        OperatorQueue.Add(token);
                        break;
                    }

                    int currentPrecedence = Precedence[token.Literal];
                    int lastPrecedence = Precedence[OperatorQueue.Last().Literal];

                    while (OperatorQueue.Count > 0 && lastPrecedence >= currentPrecedence)
                    {
                        OutputQueue.Add(OperatorQueue.Last());
                        OperatorQueue.RemoveAt(OperatorQueue.Count - 1);
                    }
                    OperatorQueue.Add(token);
                    break;
            }
        }

        foreach (Token op in OperatorQueue)
        {
            OutputQueue.Add(op);
        }

        return [.. OutputQueue];
    }
}
