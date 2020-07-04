﻿using ATM.Usercontrols;
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

namespace ATM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow mainWindow;
        public MainWindow()
        {
            mainWindow = this;
            InitializeComponent();
            ShowAndHideUC("Login");
        }
        public void ShowAndHideUC(string nameUC)
        {
            this.ChangePinTransaction.Visibility = Visibility.Hidden;
            this.CheckBalanceTransaction.Visibility = Visibility.Hidden;
            this.Login.Visibility = Visibility.Hidden;
            this.PaymentTransaction.Visibility = Visibility.Hidden;
            this.TransferTransaction.Visibility = Visibility.Hidden;
            this.WithdrawlTransaction.Visibility = Visibility.Hidden;
            this.Staff.Visibility = Visibility.Hidden;
            this.Customer.Visibility = Visibility.Hidden;
            this.ShowMessage.Visibility = Visibility.Hidden;
            this.HowMuch.Visibility = Visibility.Hidden;
            switch (nameUC)
            {
                case "ChangePinTransaction":
                    ChangePinTransaction.Visibility = Visibility.Visible;
                    break;
                case "CheckBalanceTransaction":
                    CheckBalanceTransaction.Visibility = Visibility.Visible;
                    break;
                case "Login":
                    Login.Visibility = Visibility.Visible;
                    break;
                case "PaymentTransaction":
                    PaymentTransaction.Visibility = Visibility.Visible;
                    break;
                case "TransferTransaction":
                    TransferTransaction.Visibility = Visibility.Visible;
                    break;
                case "WithdrawlTransaction":
                    WithdrawlTransaction.Visibility = Visibility.Visible;
                    break;
                case "Staff":
                    Staff.Visibility = Visibility.Visible;
                    break;
                case "Customer":
                    Customer.Visibility = Visibility.Visible;
                    break;
                case "ShowMessageUC":
                    ShowMessage.Visibility = Visibility.Visible;
                    break;
                case "HowMuch":
                    HowMuch.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}