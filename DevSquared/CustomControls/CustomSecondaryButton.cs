using System.Windows;
using System.Windows.Controls;

namespace DevSquared.CustomControls
{
    public class CustomSecondaryButton : Button
    {
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(CustomSecondaryButton), new PropertyMetadata());

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        static CustomSecondaryButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomSecondaryButton), new FrameworkPropertyMetadata(typeof(CustomSecondaryButton)));
        }
    }
}
