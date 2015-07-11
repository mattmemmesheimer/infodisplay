using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace InfoDisplay.Gui.UserControls
{
    public class VectorImage : ContentControl
    {
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof (Brush), typeof (VectorImage), null);

        public Brush Color
        {
            get { return (Brush) GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
    }
}
