using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PVBot.Clients.Portable.States;
using PVBot.DataObjects.Models;
using System;

namespace PVBot.Clients.Portable.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageCard
    {
        public MessageCard()
        {
            InitializeComponent();
        }

        #region Properties

        public MessageState State { get; private set; }

        public MessageStates CurrentState
        {
            get => (MessageStates)GetValue(CurrentStateProperty);
            set => SetValue(CurrentStateProperty, value);
        }

        public static BindableProperty CurrentStateProperty =
            BindableProperty.Create(propertyName: nameof(CurrentState),
                returnType: typeof(MessageStates),
                declaringType: typeof(MessageCard),
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: OnStateUpdated);

        #endregion

        #region Methods

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            RefreshUI();
        }

        private void RefreshUI() => SetInitialState();

        private void SetInitialState()
        {
            var result = GetCurrentState();

            TransitionTo(result);
        }

        private MessageState GetCurrentState(MessageStates? state = null)
        {
            var currentState = state ?? CurrentState;

            switch (currentState)
            {
                case MessageStates.ChatbotOnly:
                    return new ChatbotOnlyState();
                case MessageStates.ChatbotFirts:
                    return new ChatbotFirtsState();
                case MessageStates.ChatbotMiddle:
                    return new ChatbotMiddleState();
                case MessageStates.ChatbotLast:
                    return new ChatbotLastState();
                case MessageStates.UserOnly:
                    return new UserOnlyState();
                case MessageStates.UserFirts:
                    return new UserFirtsState();
                case MessageStates.UserMiddle:
                    return new UserMiddleState();
                case MessageStates.UserLast:
                    return new UserLastState();
                default:
                    throw new InvalidOperationException();
            }
        }

        private static void OnStateUpdated(BindableObject bindable,
            object oldValue,
            object newValue)
        {
            if (!(bindable is MessageCard model))
                return;

            if (!(newValue is MessageStates state))
                return;

            model.UpdateState(state);
        }

        public void TransitionTo(MessageState state, bool isUpdatingState = false)
        {
            State = state;
            State.EnterState(this, isUpdatingState);
        }

        public void UpdateState(MessageStates state)
        {
            var result = GetCurrentState(state);

            TransitionTo(result, true);
        }



        #endregion
    }
}
