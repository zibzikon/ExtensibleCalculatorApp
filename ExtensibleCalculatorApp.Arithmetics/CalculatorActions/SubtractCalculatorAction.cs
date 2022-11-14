namespace ExtensibleCalculatorApp.CalculatorActions;

public class SubtractCalculatorAction : ICalculatorAction
{
    public string Description => "a - b";
    public double Execute(double left, double right) => left - right;

}