namespace DefectMapApplication.Controls.Util
{
    [ContentProperty(nameof(ConditionalContent))]
    public class If : ContentView
    {
        public object ConditionalContent
        {
            get => GetValue(ConditionalContentProperty);
            set => SetValue(ConditionalContentProperty, value);
        }

        public static readonly BindableProperty ConditionalContentProperty =
            BindableProperty.Create(nameof(ConditionalContent), typeof(object), typeof(If), propertyChanged: OnConditionChangedCallback);

        public bool Condition
        {
            get => (bool)GetValue(ConditionProperty);
            set => SetValue(ConditionProperty, value);
        }

        public static readonly BindableProperty ConditionProperty
            = BindableProperty.Create(nameof(Condition), typeof(bool), typeof(If), false, propertyChanged: OnConditionChangedCallback);

        protected static void OnConditionChangedCallback(BindableObject bindable, object _, object __)
        {
            if (bindable is If s)
            {
                s.Update();
            }
        }

        protected void Update()
        {
            Content = Condition ? ConditionalContent as View : null;
        }
    }
}