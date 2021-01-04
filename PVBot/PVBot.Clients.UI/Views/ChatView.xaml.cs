using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PVBot.Clients.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatView
    {
        public ChatView()
        {
            InitializeComponent();

            MessageCardContainer.ItemAppearing += OnItemAppearing;
        }

        private void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            ScrollToBottom(e.Item);
        }

        private void ScrollToBottom(object element)
        {
            MessageCardContainer.ScrollTo(element, ScrollToPosition.MakeVisible, true);
        }
    }
}