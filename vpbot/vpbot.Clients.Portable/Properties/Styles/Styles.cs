using Prism.DryIoc;
using Xamarin.Forms;

using VPBot.DataObjects.Properties;

namespace VPBot.Clients.Portable.Properties.Styles
{
    public static class Styles
    {
        public static Style OnlyMessageBotStyle { get; private set; }
        public static Style FistMessageBotStyle { get; private set; }
        public static Style MiddleMessageBotStyle { get; private set; }
        public static Style LastMessageBotStyle { get; private set; }

        public static Style OnlyMessageUserStyle { get; private set; }
        public static Style FistMessageUserStyle { get; private set; }
        public static Style MiddleMessageUserStyle { get; private set; }
        public static Style LastMessageUserStyle { get; private set; }


        public static void Init(PrismApplication application)
        {
            var resources = application.Resources;

            // Bot Message Styles
            OnlyMessageBotStyle = (Style)resources[ResourceKeys.OnlyMessageBotStyle];
            FistMessageBotStyle = (Style)resources[ResourceKeys.FistMessageBotStyle];
            MiddleMessageBotStyle = (Style)resources[ResourceKeys.MiddleMessageBotStyle];
            LastMessageBotStyle = (Style)resources[ResourceKeys.LastMessageBotStyle];

            // User Message Styles
            OnlyMessageUserStyle = (Style)resources[ResourceKeys.OnlyMessageUserStyle];
            FistMessageUserStyle = (Style)resources[ResourceKeys.FistMessageUserStyle];
            MiddleMessageUserStyle = (Style)resources[ResourceKeys.MiddleMessageUserStyle];
            LastMessageUserStyle = (Style)resources[ResourceKeys.LastMessageUserStyle];
        }
    }
}
