using Autofac;
using ExtensibleCalculatorApp.CalculatorActions;

namespace ExtensibleCalculatorApp.Modules;

public class ArithmeticsModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AddCalculatorAction>().As<ICalculatorAction>();
        builder.RegisterType<DivideCalculatorAction>().As<ICalculatorAction>();
        builder.RegisterType<MultiplyCalculatorAction>().As<ICalculatorAction>();
        builder.RegisterType<SubtractCalculatorAction>().As<ICalculatorAction>();
    }
}