using Autofac;
using ExtensibleCalculatorApp.Modules;

public class ApplicationLoader
{
    private readonly PluginsLoader _pluginsLoader;

    public ApplicationLoader(PluginsLoader pluginsLoader)
    {
        _pluginsLoader = pluginsLoader;
    }
    
    public IContainer BuildContainer()
    {
        var builder = new ContainerBuilder();
        
        builder.RegisterModule<ArithmeticsModule>();
        builder.RegisterModule<ApplicationModule>();
        
        _pluginsLoader.LoadPlugins(builder);
        
        return builder.Build();
    }
}