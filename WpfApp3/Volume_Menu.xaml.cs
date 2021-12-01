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
    /// Volume_Menu.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Volume_Menu : Page
    {
        public Volume_Menu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(
                new Uri("/RotateVolume.xaml", UriKind.Relative)
                );

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(
               new Uri("/wheel_Event.xaml", UriKind.Relative)
               );
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(
                new Uri("/MousePointer.xaml", UriKind.Relative)
                );
        }
    }
}
