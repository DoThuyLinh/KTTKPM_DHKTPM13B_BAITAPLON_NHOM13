using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ATM.Usercontrols
{
    /// <summary>
    /// Interaction logic for HowMuch.xaml
    /// </summary>
    public partial class HowMuch : UserControl
    {
        public HowMuch()
        {
            InitializeComponent();
        }

        private void btn500_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn1000_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn1500_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn2000_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn300_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOther_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.ShowAndHideUC("Login");
        }
    }
}
