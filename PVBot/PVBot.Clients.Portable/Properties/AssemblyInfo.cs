using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

[assembly: Preserve(AllMembers = true)]

[assembly: XmlnsDefinition("http://pvbot.com/resources", "PVBot.Clients.Portable.Resources")]
[assembly: XmlnsDefinition("http://pvbot.com", "PVBot.Clients.Portable.Controls")]

[assembly: ExportFont("FontAwesome5Brands.otf", Alias = "FA5B")]
[assembly: ExportFont("FontAwesome5Regular.otf", Alias = "FA5R")]
[assembly: ExportFont("FontAwesome5Solid.otf", Alias = "FA5S")]
