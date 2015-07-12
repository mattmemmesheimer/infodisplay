using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
namespace InfoDisplay.Gui.UserControls
{
    /// <summary>
    /// Interaction logic for LoadingSpinner.xaml
    /// </summary>
    public partial class LoadingSpinner
    {
        #region Constants

        private const double NumberOfDegreesInCircle = 360;
        private const double NumberOfDegreesInHalfCircle = NumberOfDegreesInCircle / 2;
        private const double FullOpacity = 1.0;

        private const int DefaultHeight = 25;
        private const int DefaultWidth = 25;
        private const int DefaultSpeed = 100;
        private const int DefaultSpokes = 10;
        private const int DefaultSpokeThickness = 5;
        private const int DefaultInnerCircleRadius = 10;
        private const int DefaultOuterCircleRadius = 20;
        private static readonly Color DefaultColor = Colors.Black;

        #endregion

        #region Dependency Properties

        /// <summary>
        /// Number of spokes dependency property.
        /// </summary>
        public static readonly DependencyProperty SpokesProperty;

        /// <summary>
        /// Spokes color dependency property.
        /// </summary>
        public static readonly DependencyProperty ColorProperty;

        /// <summary>
        /// Inner circle radius dependency property.
        /// </summary>
        public static readonly DependencyProperty InnerCircleRadiusProperty;

        /// <summary>
        /// Outer circle radius dependency property.
        /// </summary>
        public static readonly DependencyProperty OuterCircleRadiusProperty;

        /// <summary>
        /// Speed dependency property.
        /// </summary>
        public static readonly DependencyProperty SpeedProperty;

        /// <summary>
        /// Spoke thickness property.
        /// </summary>
        public static readonly DependencyProperty SpokeThicknessProperty;

        static LoadingSpinner()
        {
            SpokesProperty = DependencyProperty.Register("Spokes", typeof(int),
                typeof(LoadingSpinner), new PropertyMetadata(DefaultSpokes));

            ColorProperty = DependencyProperty.Register("Color", typeof(Color),
                typeof(LoadingSpinner), new PropertyMetadata(DefaultColor));

            InnerCircleRadiusProperty = DependencyProperty.Register("InnerCircleRadius",
                typeof(int), typeof(LoadingSpinner),
                new PropertyMetadata(DefaultInnerCircleRadius));

            OuterCircleRadiusProperty = DependencyProperty.Register("OuterCircleRadius",
                typeof(int), typeof(LoadingSpinner),
                new PropertyMetadata(DefaultOuterCircleRadius));

            SpeedProperty = DependencyProperty.Register("Speed", typeof(int),
                typeof(LoadingSpinner), new PropertyMetadata(DefaultSpeed));

            SpokeThicknessProperty = DependencyProperty.Register("SpokeThickness", typeof(int),
                typeof(LoadingSpinner), new PropertyMetadata(DefaultSpokeThickness));
        }

        #endregion

        #region Properties

        /// <summary>
        /// Number of spokes.
        /// </summary>
        public int Spokes
        {
            get { return (int)GetValue(SpokesProperty); }
            set { SetValue(SpokesProperty, value); }
        }

        /// <summary>
        /// Color of spokes.
        /// </summary>
        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        /// <summary>
        /// Radius of inner circle.
        /// </summary>
        public int InnerCircleRadius
        {
            get { return (int)GetValue(InnerCircleRadiusProperty); }
            set { SetValue(InnerCircleRadiusProperty, value); }
        }

        /// <summary>
        /// Radius of outer circle.
        /// </summary>
        public int OuterCircleRadius
        {
            get { return (int)GetValue(OuterCircleRadiusProperty); }
            set { SetValue(OuterCircleRadiusProperty, value); }
        }

        /// <summary>
        /// Speed of spinner.  Higher is slower.
        /// </summary>
        public int Speed
        {
            get { return (int)GetValue(SpeedProperty); }
            set { SetValue(SpeedProperty, value); }
        }

        /// <summary>
        /// Thickness of each spoke.
        /// </summary>
        public int SpokeThickness
        {
            get { return (int)GetValue(SpokeThicknessProperty); }
            set { SetValue(SpokeThicknessProperty, value); }
        }

        #endregion

        /// <summary>
        /// Public constructor.
        /// </summary>
        public LoadingSpinner()
        {
            InitializeComponent();
            Loaded += LoadingSpinner_Loaded;
            Unloaded += LoadingSpinner_Unloaded;
        }

        private void LoadingSpinner_Loaded(object sender, RoutedEventArgs e)
        {
            Height = Height > 0 ? Height : DefaultHeight;
            Width = Width > 0 ? Width : DefaultWidth;

            _colorBrush = new SolidColorBrush(Color);
            _centerPoint = GetControlCenterPoint(this);
            _angles = GetSpokesAngles(Spokes);

            _timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, Speed)
            };
            _timer.Tick += TimerTick;
            _timer.Start();

            AddSpokes();
        }

        private void LoadingSpinner_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Tick -= TimerTick;
            }
            _timer = null;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            Step();
        }

        /// <summary>
        /// Sets the current spoke to be fully opaque.  Sets each subsequent spoke to be
        /// decreasingly opaque.
        /// </summary>
        private void Step()
        {
            double opacity = FullOpacity;
            double opacityAmount = (opacity / Spokes);

            for (int i = _currentSpoke; i < Spokes; i++)
            {
                LayoutRoot.Children[i].Opacity = opacity;
                opacity -= opacityAmount;
                opacity = opacity < 0 ? 0 : opacity;
            }
            for (int i = 0; i < _currentSpoke; i++)
            {
                LayoutRoot.Children[i].Opacity = opacity;
                opacity -= opacityAmount;
                opacity = opacity < 0 ? 0 : opacity;
            }

            _currentSpoke++;
            if (_currentSpoke >= Spokes)
            {
                _currentSpoke = 0;
            }
        }

        /// <summary>
        /// Adds spokes to the circle.
        /// </summary>
        private void AddSpokes()
        {
            // Need to clear our children in case we readd spokes
            LayoutRoot.Children.Clear();
            for (int i = 0; i < Spokes; i++)
            {
                Point p1 = GetPoint(_centerPoint, InnerCircleRadius, _angles[i]);
                Point p2 = GetPoint(_centerPoint, OuterCircleRadius, _angles[i]);
                AddSpoke(p1, p2);
            }
        }

        /// <summary>
        /// Adds a spoke to the circle.
        /// </summary>
        /// <param name="p1">Start point of spoke.</param>
        /// <param name="p2">End point of spoke.</param>
        private void AddSpoke(Point p1, Point p2)
        {
            var line = new Line
            {
                X1 = p1.X,
                X2 = p2.X,
                Y1 = p1.Y,
                Y2 = p2.Y,
                StrokeThickness = SpokeThickness,
                Stroke = _colorBrush,
                StrokeStartLineCap = PenLineCap.Round,
                StrokeEndLineCap = PenLineCap.Round
            };

            LayoutRoot.Children.Add(line);
        }

        /// <summary>
        /// Determines a point on the circle.
        /// </summary>
        /// <param name="circleCenterPoint">Center point of the circle.</param>
        /// <param name="radius">Radius of the circle.</param>
        /// <param name="angle">Angle of the spoke.</param>
        /// <returns></returns>
        private static Point GetPoint(Point circleCenterPoint, int radius, double angle)
        {
            angle = Math.PI * angle / NumberOfDegreesInHalfCircle;

            var point = new Point
            {
                X = circleCenterPoint.X + radius * Math.Cos(angle),
                Y = circleCenterPoint.Y + radius * Math.Sin(angle)
            };

            return point;
        }

        /// <summary>
        /// Determines the center point of a control.
        /// </summary>
        /// <param name="control">Control to get the center point of.</param>
        /// <returns>The center point of the control.</returns>
        private static Point GetControlCenterPoint(Control control)
        {
            return new Point(control.Width / 2, control.Height / 2 - 1);
        }

        /// <summary>
        /// Gest an array of angles for the spokes.
        /// </summary>
        /// <param name="numSpokes">Number of spokes.</param>
        /// <returns>Array of angles.</returns>
        private static double[] GetSpokesAngles(int numSpokes)
        {
            var angles = new double[numSpokes];
            double angle = NumberOfDegreesInCircle / numSpokes;

            for (int i = 0; i < numSpokes; i++)
            {
                angles[i] = (i == 0 ? angle : angles[i - 1] + angle);
            }

            return angles;
        }

        #region Fields

        private double[] _angles;
        private Point _centerPoint;
        private SolidColorBrush _colorBrush;
        // The "current" spoke is the spoke that is fully opaque.
        private int _currentSpoke;
        private DispatcherTimer _timer;

        #endregion
    }
}
