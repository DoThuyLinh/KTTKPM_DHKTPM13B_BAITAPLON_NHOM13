﻿using System;
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
    /// Interaction logic for PaymentTransactionUC.xaml
    /// </summary>
    public partial class PaymentTransactionUC : UserControl
    {
        public PaymentTransactionUC()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.ShowAndHideUC("Login");
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}