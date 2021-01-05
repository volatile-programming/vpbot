using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PVBot.Clients.Portable.States;
using PVBot.DataObjects.Models;

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

            UpdateState();
        }

        public void UpdateState(MessageState state = null)
        {
            var newState = state ?? MessageState.GetCurrentState(this, CurrentState);

            State = newState;
        }

        private static void OnStateUpdated(BindableObject bindable,
            object oldValue,
            object newValue)
        {
            if (!(bindable is MessageCard model))
                return;

            if (!(newValue is MessageStates state))
                return;

            if (model.State != null)
                model.State.TransitionTo(state);
        }

        #endregion
    }
}
