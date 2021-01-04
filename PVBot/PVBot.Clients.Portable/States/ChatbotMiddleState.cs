using Xamarin.Forms;
using PVBot.Clients.Portable.Controls;
using PVBot.DataObjects.Properties;

namespace PVBot.Clients.Portable.States
{
    public class UserOnlyState : MessageState
    {
        protected override void SetState()
        {
            // Main container
            Context.MainContainer.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.OnlyMessageUserStyle);

            // User Imagge
            Context.UserImageBackground.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.ChatImageBackgroundUserStyle);

            Grid.SetRowSpan(Context.UserImageContainer, 2);
            Grid.SetColumnSpan(Context.UserImageContainer, 2);

            var horizontalOption = LayoutOptions.End;
            Context.UserImageBackground.HorizontalOptions = horizontalOption;
            Context.UserImage.HorizontalOptions = horizontalOption;

            var verticalOption = LayoutOptions.Start;
            Context.UserImageBackground.VerticalOptions = verticalOption;
            Context.UserImage.VerticalOptions = verticalOption;

            // Mesage content
            Context.MessageContainer.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.MessageContainerUserStyle);
            Context.MessageText.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.ChatTextUserStyle);

            Context.MessageContainer.HorizontalOptions = horizontalOption;

            Grid.SetRow(Context.MessageContainer, 1);
            Grid.SetColumn(Context.MessageContainer, 0);

            // Mesage Date
            Context.DateLabel.HorizontalTextAlignment = TextAlignment.End;

            Grid.SetRow(Context.DateLabel, 2);
            Grid.SetColumn(Context.DateLabel, 0);
        }

        protected override void UpdateState(bool isUpdatingState = false) { }
    }

    public class UserFirtsState : MessageState
    {
        protected override void SetState()
        {
            // Main container
            Context.MainContainer.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.FistMessageUserStyle);

            // User Imagge
            Context.UserImageBackground.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.ChatImageBackgroundUserStyle);

            Grid.SetRowSpan(Context.UserImageContainer, 2);
            Grid.SetColumnSpan(Context.UserImageContainer, 2);

            var horizontalOption = LayoutOptions.End;
            Context.UserImageBackground.HorizontalOptions = horizontalOption;
            Context.UserImage.HorizontalOptions = horizontalOption;

            var verticalOption = LayoutOptions.Start;
            Context.UserImageBackground.VerticalOptions = verticalOption;
            Context.UserImage.VerticalOptions = verticalOption;

            // Mesage content
            Context.MessageContainer.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.MessageContainerUserStyle);
            Context.MessageText.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.ChatTextUserStyle);

            Context.MessageContainer.HorizontalOptions = horizontalOption;

            Grid.SetRow(Context.MessageContainer, 1);
            Grid.SetColumn(Context.MessageContainer, 0);

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
                    ResourceKeys.FistMessageUserStyle);
        }
    }

    public class UserLastState : MessageState
    {
        protected override void SetState()
        {
            // Main container
            Context.MainContainer.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.LastMessageUserStyle);

            // User Imagge
            Context.UserImageBackground.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.ChatImageBackgroundUserStyle);

            Context.UserImageBackground.IsVisible = false;
            Context.UserImage.IsVisible = false;

            // Mesage content
            Context.MessageContainer.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.MessageContainerUserStyle);
            Context.MessageText.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.ChatTextUserStyle);

            Context.MessageContainer.HorizontalOptions = LayoutOptions.End;

            Grid.SetRow(Context.MessageContainer, 0);
            Grid.SetColumn(Context.MessageContainer, 0);

            UpdateState();
        }

        protected override void UpdateState(bool isUpdatingState = false)
        {
            // Main container
            if (isUpdatingState)
                Context.MainContainer.SetDynamicResource(VisualElement.StyleProperty,
                    ResourceKeys.LastMessageUserStyle);

            // Mesage Date
            Context.DateLabel.HorizontalTextAlignment = TextAlignment.End;

            Grid.SetRow(Context.DateLabel, 1);
            Grid.SetColumn(Context.DateLabel, 0);

        }
    }

    public class UserMiddleState : MessageState
    {
        protected override void SetState()
        {
            // User Image
            Context.UserImageBackground.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.ChatImageBackgroundUserStyle);

            // Mesage content
            Context.MessageContainer.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.MessageContainerUserStyle);
            Context.MessageText.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.ChatTextUserStyle);

            Context.MessageContainer.HorizontalOptions = LayoutOptions.End;

            Grid.SetColumn(Context.MessageContainer, 0);

            UpdateState();
        }

        protected override void UpdateState(bool isUpdatingState = false)
        {
            Context.UserImageBackground.IsVisible = false;
            Context.UserImage.IsVisible = false;

            // Mesage Date
            Grid.SetRow(Context.DateLabel, 0);

            Context.DateLabel.IsVisible = false;

            // Main container
            Context.MainContainer.SetDynamicResource(VisualElement.StyleProperty,
                ResourceKeys.MiddleMessageUserStyle);
        }
    }
}
