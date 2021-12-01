using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// wheel_Event.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class wheel_Event : Page
    {
        int num = 0;
        public wheel_Event()
        {
            InitializeComponent();
        }
        private void Image_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
                Volume_UP();

            else if (e.Delta < 0)
                Volume_Down();
        }
        private void Volume_UP()
        {
            if (num == 360)
            {
                num = 0;
            }
            num += 10;
            Volume.LayoutTransform = new RotateTransform(num);
        }

        private void Volume_Down()
        {
            if (num == 360)
            {
                num = 0;
            }
            num -= 10;
            Volume.LayoutTransform = new RotateTransform(num);
        }    
    }
}
