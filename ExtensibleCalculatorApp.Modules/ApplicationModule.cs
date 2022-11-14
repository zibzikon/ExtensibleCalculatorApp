using Autofac;

namespace ExtensibleCalculatorApp.Modules;

public class ApplicationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CalculatorApp>().AsSelf();
    }
}