using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using VPBot.DataObjects.Models;
using VPBot.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VPBot.Clients.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatView
    {
        public ChatViewModel ViewModel { get; private set; }

        public ChatView()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            ViewModel = BindingContext as ChatViewModel;
            ViewModel.Messages.CollectionChanged += OnCollectionChanged;
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ScrollToBottom(e.NewItems[e.NewItems.Count - 1]);
        }

        private void ScrollToBottom(object element)
        {
            MessageCardContainer.ScrollTo(element, ScrollToPosition.MakeVisible, true);
        }
    }
}