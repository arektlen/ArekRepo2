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

        /// <summary>
        /// ctor
        /// </summary>
        public UserSettings()
        {
            settings.DefaultSettings();
            InitializeComponent();
            ComboBoxOrdersOnPageSet();
            ComboBoxDateFromSet();
            ComboBoxDateToSet();   
        }

        /// <summary>
        /// Zapisywanie ustawień użytkownika (button)
        /// </summary>
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        /// <summary>
        /// Ustawianie liczby zleceń na stronie
        /// </summary>
        private void comboBoxOrdersOnPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            settings.OrdersCount = (OrdersCount)comboBoxOrdersOnPage.SelectedItem;
        }

        /// <summary>
        /// Ustawianie z ilu miesięcy wstecz wyświetlać zlecenia
        /// </summary>
        private void comboBoxDateFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            settings.DateFrom = (int)comboBoxDateFrom.SelectedItem;
        }

        /// <summary>
        /// Ustawianie ile miesięcy w przód wyświetlać zlecenia
        /// </summary>
        private void comboBoxDateTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            settings.DateTo = (int)comboBoxDateTo.SelectedItem;
        }

        /// <summary>
        /// Dodawanie items do comboBox
        /// </summary>
        private void ComboBoxOrdersOnPageSet()
        {
            comboBoxOrdersOnPage.Items.Add(settings.ordersAll);
            comboBoxOrdersOnPage.Items.Add(settings.orders10);
            comboBoxOrdersOnPage.Items.Add(settings.orders20);
            comboBoxOrdersOnPage.Items.Add(settings.orders30);
            comboBoxOrdersOnPage.Items.Add(settings.orders40);
            comboBoxOrdersOnPage.Text = settings.OrdersCount.Text;
        }

        /// <summary>
        /// Dodawanie items do comboBox
        /// </summary>
        private void ComboBoxDateFromSet() 
        {
            comboBoxDateFrom.Items.Add(-1);
            comboBoxDateFrom.Items.Add(-2);
            comboBoxDateFrom.Items.Add(-3);
            comboBoxDateFrom.Items.Add(-6);
            comboBoxDateFrom.Items.Add(-12);
        }

        /// <summary>
        /// Dodawanie items do comboBox
        /// </summary>
        private void ComboBoxDateToSet()
        {
            comboBoxDateTo.Items.Add(0);
            comboBoxDateTo.Items.Add(1);
            comboBoxDateTo.Items.Add(2);
            comboBoxDateTo.Items.Add(3);
            comboBoxDateTo.Items.Add(6);
            comboBoxDateTo.Items.Add(12);
        }
    }
}
