using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DevSquared.CustomControls
{
    public class CustomPasswordBox : Control
    {
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(CustomPasswordBox), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register("Placeholder", typeof(string), typeof(CustomPasswordBox), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(CustomPasswordBox), new PropertyMetadata());

        private static readonly DependencyPropertyKey IsEmptyPropertyKey =
            DependencyProperty.RegisterReadOnly("IsEmpty", typeof(bool), typeof(CustomPasswordBox), new PropertyMetadata(true));
        public static readonly DependencyProperty IsEmptyProperty = IsEmptyPropertyKey.DependencyProperty;

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
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

        static CustomPasswordBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomPasswordBox), new FrameworkPropertyMetadata(typeof(CustomPasswordBox)));
            FocusableProperty.OverrideMetadata(typeof(CustomPasswordBox), new FrameworkPropertyMetadata(false));
            KeyboardNavigation.TabNavigationProperty.OverrideMetadata(typeof(CustomPasswordBox), new FrameworkPropertyMetadata(KeyboardNavigationMode.Local));
        }

        public override void OnApplyTemplate()
        {
            PasswordBox passwordBox = (PasswordBox)GetTemplateChild("passwordBox");
            passwordBox.PasswordChanged += (s, e) =>
            {
                Password = passwordBox.Password;
                IsEmpty = string.IsNullOrEmpty(Password);
            };
            base.OnApplyTemplate();
        }
    }
}
