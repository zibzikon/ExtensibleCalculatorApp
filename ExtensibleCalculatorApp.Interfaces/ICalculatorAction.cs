namespace ExtensibleCalculatorApp;

public interface ICalculatorAction
{
    string Description { get; }
    double Execute(double left, double right);
}