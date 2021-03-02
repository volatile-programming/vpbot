using Prism.DryIoc;
using Prism.Ioc;

namespace VPBot.Clients.Portable
{
    public static class VPBotPortable
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
