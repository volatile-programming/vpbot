using System;
using Xamarin.Forms;

using PVBot.Clients.Portable.Controls;
using PVBot.DataObjects.Properties;
using PVBot.DataObjects.Models;

namespace PVBot.Clients.Portable.States
{
    public abstract class MessageState
    {
        protected MessageCard Context { get; set; }

        public void TransitionTo(MessageStates nextState)
        {
            var newState = GetCurrentState(Context, nextState, true);

            Context.UpdateState(newState);
        }

        private void EnterState(MessageCard context, bool isUpdatingState)
        {
            Context = context;

            if (isUpdatingState)
                UpdateState(isUpdatingState);
            else
                SetState();
        }

        public static MessageState GetCurrentState(MessageCard context, MessageStates state)
            => GetCurrentState(context, state, false);

        private static MessageState GetCurrentState(MessageCard context,
            MessageStates state,
            bool isUpdatingState)
        {
            var stateName = Enum.GetName(typeof(MessageStates), state);
            var type = Type.GetType($"PVBot.Clients.Portable.States.{stateName}");
            var newState = (MessageState)Activator.CreateInstance(type);

            newState.EnterState(context, isUpdatingState);

            return newState;
        }

        protected abstract void SetState();

        protected abstract void UpdateState(bool isUpdatingState = false);
    }

    public class ChatbotOnlyState : MessageState
    {
        protected override void SetState()
        {
            // Main container
            Context.MainContainer.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.OnlyMessageBotStyle);

            // User Imagge
            Context.UserImageBackground.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.ChatImageBackgroundBotStyle);

            Grid.SetRowSpan(Context.UserImageContainer, 2);
            Grid.SetColumnSpan(Context.UserImageContainer, 2);

            var horizontalOption = LayoutOptions.Start;
            Context.UserImageBackground.HorizontalOptions = horizontalOption;
            Context.UserImage.HorizontalOptions = horizontalOption;

            var verticalOption = LayoutOptions.Start;
            Context.UserImageBackground.VerticalOptions = verticalOption;
            Context.UserImage.VerticalOptions = verticalOption;

            // Mesage content
            Context.MessageContainer.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.MessageContainerBotStyle);
            Context.MessageText.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.ChatTextBotStyle);

            Context.MessageContainer.HorizontalOptions = horizontalOption;

            Grid.SetRow(Context.MessageContainer, 1);
            Grid.SetColumn(Context.MessageContainer, 1);

            // Mesage Date
            Context.DateLabel.HorizontalTextAlignment = TextAlignment.Start;

            Grid.SetRow(Context.DateLabel, 2);
            Grid.SetColumn(Context.DateLabel, 1);
        }

        protected override void UpdateState(bool isUpdatingState = false) { }
    }

    public class ChatbotFirtsState : MessageState
    {
        protected override void SetState()
        {
            // Main container
            Context.MainContainer.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.FistMessageBotStyle);

            // User Imagge
            Context.UserImageBackground.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.ChatImageBackgroundBotStyle);

            Grid.SetRowSpan(Context.UserImageContainer, 2);
            Grid.SetColumnSpan(Context.UserImageContainer, 2);

            var horizontalOption = LayoutOptions.Start;
            Context.UserImageBackground.HorizontalOptions = horizontalOption;
            Context.UserImage.HorizontalOptions = horizontalOption;

            var verticalOption = LayoutOptions.Start;
            Context.UserImageBackground.VerticalOptions = verticalOption;
            Context.UserImage.VerticalOptions = verticalOption;

            // Mesage content
            Context.MessageContainer.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.MessageContainerBotStyle);
            Context.MessageText.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.ChatTextBotStyle);

            Context.MessageContainer.HorizontalOptions = horizontalOption;

            Grid.SetRow(Context.MessageContainer, 1);
            Grid.SetColumn(Context.MessageContainer, 1);

            UpdateState();
        }

        protected override void UpdateState(bool isUpdatingState = false)
        {
            // Mesage Date
            Grid.SetRow(Context.DateLabel, 0);
            Grid.SetColumn(Context.DateLabel, 0);

            Context.DateLabel.IsVisible = false;

            // Main container
            if (isUpdatingState)
                Context.MainContainer.SetDynamicResource(VisualElement.StyleProperty,
                    ResourceKeys.FistMessageBotStyle);
        }
    }

    public class ChatbotLastState : MessageState
    {
        protected override void SetState()
        {
            // Main container
            Context.MainContainer.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.LastMessageBotStyle);

            // User Imagge
            Context.UserImageBackground.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.ChatImageBackgroundBotStyle);

            Context.UserImageBackground.IsVisible = false;
            Context.UserImage.IsVisible = false;

            // Mesage content
            Context.MessageContainer.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.MessageContainerBotStyle);
            Context.MessageText.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.ChatTextBotStyle);

            Context.MessageContainer.HorizontalOptions = LayoutOptions.Start;

            Grid.SetRow(Context.MessageContainer, 0);
            Grid.SetColumn(Context.MessageContainer, 1);

            UpdateState();
        }

        protected override void UpdateState(bool isUpdatingState = false)
        {
            // Main container
            if (isUpdatingState)
                Context.MainContainer.SetDynamicResource(VisualElement.StyleProperty,
                    ResourceKeys.LastMessageBotStyle);

            // Mesage Date
            Context.DateLabel.HorizontalTextAlignment = TextAlignment.Start;

            Grid.SetRow(Context.DateLabel, 1);
            Grid.SetColumn(Context.DateLabel, 1);
        }
    }

    public class ChatbotMiddleState : MessageState
    {
        protected override void SetState()
        {
            // User Imagge
            Context.UserImageBackground.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.ChatImageBackgroundBotStyle);

            // Mesage content
            Context.MessageContainer.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.MessageContainerBotStyle);
            Context.MessageText.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.ChatTextBotStyle);

            Context.MessageContainer.HorizontalOptions = LayoutOptions.Start;

            Grid.SetColumn(Context.MessageContainer, 1);

            UpdateState();
        }

        protected override void UpdateState(bool isUpdatingState = false)
        {
            // User Imagge
            Context.UserImageBackground.IsVisible = false;
            Context.UserImage.IsVisible = false;

            // Mesage Date
            Grid.SetRow(Context.DateLabel, 0);

            Context.DateLabel.IsVisible = false;

            // Main container
            Context.MainContainer.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.MiddleMessageBotStyle);
        }
    }
}
