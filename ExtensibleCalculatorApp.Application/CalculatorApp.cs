namespace ExtensibleCalculatorApp;

public class CalculatorApp
{
    private readonly ICalculatorAction[] _calculatorActions;

    public CalculatorApp(ICalculatorAction[] calculatorActions)
    {
        _calculatorActions = calculatorActions;
    }
    
    public void Run()
    {
        var needContinue = true;
        do
        {
            WriteCalculatorActionsDescriptions();

            var @operator = int.Parse(Console.ReadLine()!);
            var left = double.Parse(Console.ReadLine()!);
            var right = double.Parse(Console.ReadLine()!);

            if (@operator < 1 || @operator > _calculatorActions.Length)
                throw new IndexOutOfRangeException();

            var result = _calculatorActions[@operator - 1].Execute(left, right);
            
            Console.WriteLine(result);
            
            Console.WriteLine("calc smth else 'yes' 'no'");
            
            needContinue = Console.ReadLine()?.ToLowerInvariant() is "yes";

        } 
        while (needContinue);
        
    }

    private void WriteCalculatorActionsDescriptions()
    {
        for (var index = 0; index < _calculatorActions.Length; index++)
        {
            var calculatorAction = _calculatorActions[index];
            Console.WriteLine($"{index + 1}({calculatorAction.Description})");
        }
    }
}