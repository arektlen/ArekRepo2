using System;
using System.Windows;
using System.Windows.Controls;
using OrdersRegistration.DbRepository;
using MahApps.Metro.Controls;
using OrdersRegistration.Validation;

namespace OrdersRegistration.WPF
{
    /// <summary>
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    public partial class AddOrder : MetroWindow
    {
        private IStorable<Model.Order> _orderStorage;
        private IStorable<Model.Customer> _customerStorage;
        private Model.Order newOrder = new Model.Order();

        /// <summary>
        /// ctor
        /// </summary>
        public AddOrder(IStorable<Model.Order> orderStorage, IStorable<Model.Customer> customerStorage)
        {
            _orderStorage = orderStorage;
            _customerStorage = customerStorage;
            InitializeComponent();
            comboBoxSelectCustomer.ItemsSource = _customerStorage.Read();
            newOrder.Customer = new Model.Customer();
            dateOrderPicker.SelectedDate = DateTime.Now;
        }

        /// <summary>
        /// Wybranie nowego zleceniodawcy
        /// </summary>
        private void cBselectCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            newOrder.Customer = (Model.Customer)comboBoxSelectCustomer.SelectedItem;
        }

        /// <summary>
        /// Nazwa zlecenia
        /// </summary>
        private void tBordername_TextChanged(object sender, TextChangedEventArgs e)
        {
            newOrder.Name = textBoxOrdername.Text;
        }

        /// <summary>
        /// Komentarz (opcjonalny)
        /// </summary>
        private void tBcomments_TextChanged(object sender, TextChangedEventArgs e)
        {
            newOrder.Comments = textBoxComments.Text;
        }

        /// <summary>
        /// Data zlecenia
        /// </summary>
        private void dateOrderPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            newOrder.Date = dateOrderPicker.SelectedDate.Value;
        }

        /// <summary>
        /// Dodanie nowego zlecnia do bazy danych (Button)
        /// </summary>
        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxOrdername.Text != "" && newOrder.Date != null && textBoxOrderPrice.Text != "" && newOrder.Customer.ID != 0)
            {
                _orderStorage.Create(newOrder);
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Musisz uzupełnić pola oznaczone GWIAZDKĄ!", "Uwaga!");
            } 
        }

        /// <summary>
        /// Kwota zlecenia
        /// </summary>
        private void textBoxOrderPrice_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Validators.IsDigitValidation(textBoxOrderPrice.Text))
            {
                decimal price;
                if (decimal.TryParse(textBoxOrderPrice.Text, out price))
                {
                    newOrder.Price = price;
                }
            }
            else
            {
                MessageBox.Show("Musisz podać cyfry!", "Uwaga!");
                textBoxOrderPrice.Clear();
            }
        }
    }
}
