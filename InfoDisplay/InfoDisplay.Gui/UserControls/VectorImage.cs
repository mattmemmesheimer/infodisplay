using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace InfoDisplay.Gui.UserControls
{
    /// <summary>
    /// <see cref="ContentControl"/> with a <see cref="Brush"/> property used to render SVG data.
    /// </summary>
    public class VectorImage : ContentControl
    {
        /// <summary>
        /// Color dependency property.
        /// </summary>
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof (Brush), typeof (VectorImage), null);

        /// <summary>
        /// Color of the vector image.
        /// </summary>
        public Brush Color
        {
            get { return (Brush) GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
    }
}
