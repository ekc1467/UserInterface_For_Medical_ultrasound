using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp3
{
    public class RotateButton : Control
    {
        #region private variables
        private Point previousPoint;
        private Point currentPoint;
        private Point centerPoint;

        #endregion

        #region property

        public int MaxSize
        {
            get { return (int)GetValue(MaxSizeProperty); }
            set { SetValue(MaxSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxSizeProperty =
            DependencyProperty.Register("MaxSize", typeof(int), typeof(RotateButton), new PropertyMetadata(100));

        public int MinSize
        {
            get { return (int)GetValue(MinSizeProperty); }
            set { SetValue(MinSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinSizeProperty =
            DependencyProperty.Register("MinSize", typeof(int), typeof(RotateButton), new PropertyMetadata(0));

        public int Value
        {
            get { 
                    return (int)GetValue(ValueProperty); 
            }
            set { SetValue(ValueProperty, Math.Max(Math.Min(value, MaxSize), MinSize)); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(RotateButton), new PropertyMetadata(0));

        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Angle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(double), typeof(RotateButton), new PropertyMetadata(0D));

        public int StepSize
        {
            get { return (int)GetValue(StepSizeProperty); }
            set { SetValue(StepSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StepSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StepSizeProperty =
            DependencyProperty.Register("StepSize", typeof(int), typeof(RotateButton), new PropertyMetadata(1));

        public int RotationRate
        {
            get { return (int)GetValue(RotationRateProperty); }
            set { SetValue(RotationRateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RotationRate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RotationRateProperty =
            DependencyProperty.Register("RotationRate", typeof(int), typeof(RotateButton), new PropertyMetadata(10));

        #endregion


        static RotateButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RotateButton), new FrameworkPropertyMetadata(typeof(RotateButton)));
            
        }

        public override void OnApplyTemplate()
        {
            Grid GridPointRotateButton;
            Grid GridRotateButton;
            GridPointRotateButton = Template.FindName(nameof(GridPointRotateButton), this) as Grid;
            GridRotateButton = Template.FindName(nameof(GridRotateButton), this) as Grid;

            GridRotateButton.MouseLeftButtonDown += (s,e) => GridPointRotateButton_MouseDown(s);
            GridRotateButton.MouseMove += (s, e) => GridPointRotateButton_MouseMove(s);

            Binding BindingAngle = new Binding()
            {
                Source = this,
                Path = new PropertyPath("Angle"),
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };

            base.OnApplyTemplate();

            //binding Angle
            RotateTransform rotateTransform = new RotateTransform();

            BindingOperations.SetBinding(rotateTransform,
                                        RotateTransform.AngleProperty,
                                        BindingAngle);

            GridPointRotateButton.RenderTransform = rotateTransform;
        }

        private void GridPointRotateButton_MouseDown(object obj)
        {
            Grid grid = obj as Grid;

            if(grid != null)
            {
                centerPoint.X = grid.ActualWidth / 2;
                centerPoint.Y = grid.ActualHeight / 2;
                previousPoint = Mouse.GetPosition(grid);
            }
        }

        private void GridPointRotateButton_MouseMove(object obj)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                
                currentPoint = Mouse.GetPosition(obj as Grid);

                Vector CurrentVector = currentPoint - centerPoint;
                Vector PreviousVector = previousPoint - centerPoint;

                double AngleChanged = GetVectorAngle(PreviousVector, CurrentVector);

                Angle += AngleChanged;

                Value =StepSize * (int)(Angle / RotationRate);

                previousPoint = currentPoint;

            }
        }

        private double GetVectorAngle(Vector previous, Vector current)
        {
            return Vector.AngleBetween(previous, current);
        }

    }
}
