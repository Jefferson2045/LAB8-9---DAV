using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Bussines;
using Entity;
using Data;

namespace Demo1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Invoice> invoices = GetInvoices();
            dataGrid.ItemsSource = invoices;
        }

        private List<Invoice> GetInvoices()
        {
            DInvoice dInvoice = new DInvoice();
            return dInvoice.GetInvoices(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
