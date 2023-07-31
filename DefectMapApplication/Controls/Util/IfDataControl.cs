namespace DefectMapApplication.Controls.Util
{
    public class IfData : If
    {
        public bool Invert
        {
            get => (bool)GetValue(InvertProperty);
            set => SetValue(InvertProperty, value);
        }

        public static readonly BindableProperty InvertProperty
            = BindableProperty.Create(nameof(Condition), typeof(bool), typeof(If), false, propertyChanged: OnValuesChangedCallback);

        public object Source
        {
            get => GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public static readonly BindableProperty SourceProperty
            = BindableProperty.Create(nameof(Condition), typeof(object), typeof(If), propertyChanged: OnValuesChangedCallback);

        public object Value
        {
            get => GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly BindableProperty ValueProperty
            = BindableProperty.Create(nameof(Condition), typeof(object), typeof(If), propertyChanged: OnValuesChangedCallback);

        private static void OnValuesChangedCallback(BindableObject bindable, object _, object __)
        {
            if(bindable is IfData s)
            {
                s.Condition = s.Source?.Equals(s.Value) == !s.Invert;
            }
        }
    }
}
