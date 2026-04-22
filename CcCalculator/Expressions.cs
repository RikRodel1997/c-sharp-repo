namespace CcCalculator;

public abstract record Expression;

public record BinaryExpression(Expression Left, Expression Right, char Op) : Expression;

public record NumberExpression(double Value) : Expression;
