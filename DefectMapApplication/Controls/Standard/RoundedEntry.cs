namespace DefectMapApplication.Controls.Standard
{
    public class RoundedEntry : Entry
    {
        public static BindableProperty CornerRadiusProperty
            = BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(RoundedEntry), 0);

        public int CornerRadius
        {
            get => (int)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static BindableProperty BorderThicknessRadiusProperty
            = BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(RoundedEntry), 0);

        public int BorderThickness
        {
            get => (int)GetValue(BorderThicknessRadiusProperty);
            set => SetValue(BorderThicknessRadiusProperty, value);
        }

        public static BindableProperty PaddingProperty
            = BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(RoundedEntry), new Thickness(1));

        public Thickness Padding
        {
            get => (Thickness)GetValue(PaddingProperty);
            set => SetValue(PaddingProperty, value);
        }

        public static BindableProperty BorderColorProperty
            = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(RoundedEntry), Colors.Transparent);

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public static BindableProperty CustomHeightProperty
            = BindableProperty.Create(nameof(CustomHeight), typeof(int), typeof(RoundedEntry), 0);

        public int CustomHeight
        {
            get => (int)GetValue(BorderThicknessRadiusProperty);
            set => SetValue(BorderThicknessRadiusProperty, value);
        }
    }
}
