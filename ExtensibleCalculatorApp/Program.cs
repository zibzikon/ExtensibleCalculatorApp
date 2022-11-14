using Autofac;
using ExtensibleCalculatorApp;

var loader = new ApplicationLoader(new PluginsLoader());
var container = loader.BuildContainer();
var app = container.Resolve<CalculatorApp>();
app.Run();