using PVBot.Clients.Portable.Enums;
using PVBot.Clients.Portable.Resources;
using Xamarin.Forms;

namespace PVBot.Clients.Portable.Controls
{
    public class IconButton : ImageButton
    {
        #region Properties

        public FontFamilies FontFamily
        {
            get => (FontFamilies)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        public static readonly BindableProperty FontFamilyProperty
            = BindableProperty.Create(propertyName: nameof(FontFamily),
                returnType: typeof(FontFamilies),
                declaringType: typeof(IconButton),
                defaultValue: FontFamilies.FontAwesome5Solid);

        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly BindableProperty IconProperty
            = BindableProperty.Create(propertyName: nameof(FontFamily),
                returnType: typeof(FontFamilies),
                declaringType: typeof(IconButton),
                defaultValue: FontAwesome5Solid.Stop,
                propertyChanged: OnIconPropertyChanded);

        #endregion

        #region Methods

        protected override void OnParentSet()
        {
            base.OnParentSet();

            UpdateImageSourse();
        }

        private void UpdateImageSourse()
        {
            var fontFamily = Fonts.GetFontFamily(FontFamily);
            var icon = Icon;

            Source = new FontImageSource
            {
                FontFamily = fontFamily,
                Glyph = icon
            };
        }

        private static void OnIconPropertyChanded(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is IconButton model))
                return;

            model.UpdateImageSourse();
        }

        #endregion
    }
}
