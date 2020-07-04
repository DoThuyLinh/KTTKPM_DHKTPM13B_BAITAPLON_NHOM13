﻿using ApiModel;
using ATM.Usercontrols;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public static string account;
        public static MainWindow mainWindow;
        public MainWindow()
        {
            account = "";
            mainWindow = this;
            InitializeComponent();
            ShowAndHideUC("Login",null);
        }
        public void ShowAndHideUC(string nameUC,object obj)
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
            InputMoney.Visibility = Visibility.Hidden;
            ShowMessageBill.Visibility = Visibility.Hidden;
            ShowMessagePay.Visibility = Visibility.Hidden;
            ShowMessageBalance.Visibility = Visibility.Hidden;
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
                    Login.txtPass.Password = "";
                    Login.txtUser.Text = "";
                    break;
                case "PaymentTransaction":
                    PaymentTransaction.Visibility = Visibility.Visible;
                    break;
                case "TransferTransaction":
                    TransferTransaction.Visibility = Visibility.Visible;
                    TransferTransaction.txtTaiKhoanGui.Text = account;
                    
                    break;
                case "WithdrawlTransaction":
                    WithdrawlTransaction.Visibility = Visibility.Visible;
                    
                    break;
                case "Staff":
                    Staff.Visibility = Visibility.Visible;
                    break;
                case "Customer":
                    Customer.Visibility = Visibility.Visible;
                    if (obj != null)
                    {
                        var model = (ApiUserLoginModel)obj;
                        if (model.ErrorMessages.Count == 0)
                        {
                            Customer.txtAccount.Text = model.ApiPersonModel.AccountNumber;
                            Customer.txtName.Text = model.ApiPersonModel.PersonName;
                            account = model.ApiPersonModel.AccountNumber;
                        }
                    }
                    break;
                case "ShowMessage":
                    ShowMessage.Visibility = Visibility.Visible;

                    break;
                case "HowMuch":
                    HowMuch.Visibility = Visibility.Visible;
                    break;
                case "InputMoney":
                    InputMoney.Visibility = Visibility.Visible;
                    break;
                case "ShowMessageBill":
                    ShowMessageBill.Visibility = Visibility.Visible;
                    if (obj != null)
                    {
                        var model = (ApiWithdrawlTransactionModel)obj;
                        if (model.ErrorMessages.Count == 0)
                        {
                            ShowMessageBill.txtTransactionMoney.Text = model.TransactionMoney.ToString();
                            ShowMessageBill.txtAvailableBalance.Text = model.AvailableBalance.ToString();
                            ShowMessageBill.txtWithdrawlFee.Text = model.WithdrawlFee.ToString();
                        }
                    }
                    break;
                case "ShowMessagePay":
                    ShowMessagePay.Visibility = Visibility.Visible;
                    if (obj != null)
                    {
                        var model = (ApiTransferTransactionModel)obj;
                        if (model.ErrorMessages.Count == 0)
                        {
                            ShowMessagePay.txtTransactionMoney.Text = model.TransactionMoney.ToString();
                            ShowMessagePay.txtAvailableBalance.Text = model.AvailableBalance.ToString();
                            ShowMessagePay.txtWithdrawlFee.Text = model.TransferFee.ToString();
                        }
                    }
                    break;
                case "ShowMessageBalance":
                    ShowMessageBalance.Visibility = Visibility.Visible;
                    if (obj != null)
                    {
                        var model = (ApiCheckBalanceTransactionModel)obj;
                        if (model.ErrorMessages.Count == 0)
                        {
                            ShowMessageBalance.txtAccount.Text = account;
                            ShowMessageBalance.txtAvailableBalance.Text = model.AvailableBalance.ToString()+"  VNĐ";
                        }
                    }
                    break;
            }
        }
    }
}
