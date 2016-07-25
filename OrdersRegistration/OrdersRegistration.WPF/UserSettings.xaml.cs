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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using OrdersRegistration.DbRepository;
using OrdersRegistration.WPF.Infrastructure;
using System.IO;

namespace OrdersRegistration.WPF
{
    /// <summary>
    /// Interaction logic for UserSettings.xaml
    /// </summary>
    public partial class UserSettings : MetroWindow
    {
        public Settings settings = new Settings();

        public UserSettings()
        {
            settings.DefaultSettings(); // zmienić - formatka powinna pobierać wartości z MainWindow (chyba)
            InitializeComponent();
            ComboBoxOrdersOnPage();
            ControlsSettings();   
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void comboBoxOrdersOnPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OrdersCount ordersCount = (OrdersCount)comboBoxOrdersOnPage.SelectedItem;
            settings.OrdersCount = ordersCount;
        }

        private void datePickerDateFrom_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            settings.DateFrom = datePickerDateFrom.SelectedDate.Value;         
        }

        private void datePickerDateTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            settings.DateTo = datePickerDateTo.SelectedDate.Value;
        }

        private void ComboBoxOrdersOnPage()
        {
            Settings settings = new Settings();

            comboBoxOrdersOnPage.Items.Add(settings.ordersAll);
            comboBoxOrdersOnPage.Items.Add(settings.orders10);
            comboBoxOrdersOnPage.Items.Add(settings.orders20);
            comboBoxOrdersOnPage.Items.Add(settings.orders30);
            comboBoxOrdersOnPage.Items.Add(settings.orders40);
        }

        /// <summary>
        /// Ustawienie domyślnych wartości w kontrolkach
        /// </summary>
        private void ControlsSettings()
        {
            datePickerDateTo.SelectedDate = settings.DateTo;
            datePickerDateFrom.SelectedDate = settings.DateFrom;
            comboBoxOrdersOnPage.Text = settings.OrdersCount.Text;
        }
    }
}
