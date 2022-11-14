using Autofac;
using ExtensibleCalculatorApp;

public class PluginsLoader
{
    public void LoadPlugins(ContainerBuilder containerBuilder)
    {
        var directory = new DirectoryInfo($"{new FileInfo(GetType().Assembly.Location).Directory?.FullName}/Plugins");
        
        var dlls = directory.GetFiles("*.dll");
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        foreach (var dll in dlls?.Where(x => IsSuitable(x.FullName))!)
        {
            var defaultContext = System.Runtime.Loader.AssemblyLoadContext.Default;
            var loaded =
                assemblies.FirstOrDefault(x => x.Location.ToLowerInvariant() == dll.FullName?.ToLowerInvariant());

            if (loaded == null)
            {
                loaded = defaultContext.LoadFromAssemblyPath(dll.FullName ?? throw new InvalidOperationException());
            }

            containerBuilder.RegisterAssemblyModules(loaded);
        }
    }

    private bool IsSuitable(string path)
    {
        var type = typeof(CalculatorPluginAttribute);
        var asm = Mono.Cecil.AssemblyDefinition.ReadAssembly(path);

        return asm.CustomAttributes.Any(attribute =>
            attribute.AttributeType.Name == type.Name && attribute.AttributeType.Namespace == type.Namespace);
    }
}