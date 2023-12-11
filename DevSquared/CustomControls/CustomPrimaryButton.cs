using System.Windows;
using System.Windows.Controls;

namespace DevSquared.CustomControls
{
    public class CustomPrimaryButton : Button
    {
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(CustomPrimaryButton), new PropertyMetadata());

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        static CustomPrimaryButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomPrimaryButton), new FrameworkPropertyMetadata(typeof(CustomPrimaryButton)));
        }
    }
}
