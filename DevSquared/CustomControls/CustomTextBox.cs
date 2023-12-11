using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DevSquared.CustomControls
{
    public class CustomTextBox : Control
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(CustomTextBox), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register("Placeholder", typeof(string), typeof(CustomTextBox), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(CustomTextBox), new PropertyMetadata());

        private static readonly DependencyPropertyKey IsEmptyPropertyKey =
            DependencyProperty.RegisterReadOnly("IsEmpty", typeof(bool), typeof(CustomTextBox), new PropertyMetadata(true));
        public static readonly DependencyProperty IsEmptyProperty = IsEmptyPropertyKey.DependencyProperty;

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public bool IsEmpty
        {
            get { return (bool)GetValue(IsEmptyProperty); }
            set { SetValue(IsEmptyPropertyKey, value); }
        }

        static CustomTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomTextBox), new FrameworkPropertyMetadata(typeof(CustomTextBox)));
            FocusableProperty.OverrideMetadata(typeof(CustomTextBox), new FrameworkPropertyMetadata(false));
            KeyboardNavigation.TabNavigationProperty.OverrideMetadata(typeof(CustomTextBox), new FrameworkPropertyMetadata(KeyboardNavigationMode.Local));
        }

        public override void OnApplyTemplate()
        {
            TextBox textBox = (TextBox)GetTemplateChild("textBox");
            textBox.TextChanged += (s, e) =>
            {
                Text = textBox.Text;
                IsEmpty = string.IsNullOrEmpty(Text);
            };
            base.OnApplyTemplate();
        }
    }
}
