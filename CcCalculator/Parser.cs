namespace CcCalculator;

public class Parser(Token[] tokens)
{
    private static readonly Dictionary<string, int> Precedence = new()
    {
        { "(", 0 },
        { ")", 0 },
        { "-", 1 },
        { "+", 1 },
        { "*", 2 },
        { "/", 2 },
        { "sin", 3 },
        { "cos", 3 },
        { "tan", 3 },
    };

    private Token[] Tokens { get; set; } = tokens;

    private readonly List<Token> OperatorQueue = [];

    private readonly List<Token> OutputQueue = [];

    public Token[] Parse()
    {
        foreach (Token token in Tokens)
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
                case TokenType.Function:
                    if (OperatorQueue.Count == 0)
                    {
                        OperatorQueue.Add(token);
                        break;
                    }

                    while (OperatorQueue.Count > 0 && LastPrecedence() >= CurrentPrecedence(token))
                    {
                        OutputQueue.Add(OperatorQueue.Last());
                        OperatorQueue.RemoveAt(OperatorQueue.Count - 1);
                    }
                    OperatorQueue.Add(token);
                    break;
                default:
                    if (OperatorQueue.Count == 0)
                    {
                        OperatorQueue.Add(token);
                        break;
                    }

                    while (OperatorQueue.Count > 0 && LastPrecedence() >= CurrentPrecedence(token))
                    {
                        OutputQueue.Add(OperatorQueue.Last());
                        OperatorQueue.RemoveAt(OperatorQueue.Count - 1);
                    }
                    OperatorQueue.Add(token);
                    break;
            }
        }

        while (OperatorQueue.Count > 0)
        {
            OutputQueue.Add(OperatorQueue.Last());
            OperatorQueue.RemoveAt(OperatorQueue.Count - 1);
        }

        return [.. OutputQueue];
    }

    private static int CurrentPrecedence(Token token)
    {
        return Precedence[token.Literal];
    }

    private int LastPrecedence()
    {
        return Precedence[OperatorQueue.Last().Literal];
    }
}
