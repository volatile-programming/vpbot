using Prism.DryIoc;
using Prism.Ioc;

namespace PVBot.Clients.Portable
{
    public static class PVBotPortable
    {
        internal static PrismApplication Application { get; private set; }
        internal static IContainerProvider Container { get; private set; }

        public static void Init(PrismApplication application)
        {
            Application = application;
            Container = Application.Container;

            Properties.Styles.Styles.Init(application);
        }
    }
}
