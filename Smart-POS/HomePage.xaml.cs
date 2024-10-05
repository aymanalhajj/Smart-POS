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
using System.Windows.Shapes;
using POS_Desktop;

namespace Smart_POS
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void MaxBtn_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                if (WindowState == WindowState.Maximized)
                {
                    WindowState = WindowState.Normal;
                }
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PurchaseInvMenu_Click(object sender, RoutedEventArgs e)
        {

            //var currentWin = Application.Current.Windows[0];
            //currentWin.Hide();
            //MainWindow mainW = new MainWindow();
            //mainW.Show();
            //currentWin.Close();
            PurchaseInvoicePage page = new PurchaseInvoicePage();
            //page.ShowInTaskbar = false;
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
    }
}
