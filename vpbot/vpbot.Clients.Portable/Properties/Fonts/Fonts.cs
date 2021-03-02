using VPBot.Clients.Portable.Enums;

namespace VPBot.Clients.Portable.Properties.Fonts
{
    public static class Fonts
    {
        public const string FontAwesome5Brands = "FA5B";
        public const string FontAwesome5Regular = "FA5R";
        public const string FontAwesome5Solid = "FA5S";

        public static string GetFontFamily(FontFamilies fontFamily)
        {
            switch (fontFamily)
            {
                case FontFamilies.FontAwesome5Brands:
                    return FontAwesome5Brands;
                case FontFamilies.FontAwesome5Regular:
                    return FontAwesome5Regular;
                case FontFamilies.FontAwesome5Solid:
                    return FontAwesome5Solid;
                default:
                    return string.Empty;
            }
        }
    }
}
