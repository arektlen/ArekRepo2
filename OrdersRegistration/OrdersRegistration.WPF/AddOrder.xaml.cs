using System;
using System.Windows;
using System.Windows.Controls;
using OrdersRegistration.DbRepository;
using MahApps.Metro.Controls;

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

        public AddOrder(IStorable<Model.Order> orderStorage, IStorable<Model.Customer> customerStorage)
        {
            _orderStorage = orderStorage;
            _customerStorage = customerStorage;
            InitializeComponent();
            comboBoxSelectCustomer.ItemsSource = _customerStorage.Read();
            newOrder.Customer = new Model.Customer();
            dateOrderPicker.SelectedDate = DateTime.Now;
        }

        private void cBselectCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            newOrder.Customer = (Model.Customer)comboBoxSelectCustomer.SelectedItem;
        }

        private void tBordername_TextChanged(object sender, TextChangedEventArgs e)
        {
            newOrder.Name = textBoxOrdername.Text;
        }

        private void tborderPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal price;
            if (decimal.TryParse(textBoxOrderPrice.Text, out price))
            {
                newOrder.Price = price;
            }    
        }

        private void tBcomments_TextChanged(object sender, TextChangedEventArgs e)
        {
            newOrder.Comments = textBoxComments.Text;
        }

        private void dateOrderPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            newOrder.Date = dateOrderPicker.SelectedDate.Value;
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            _orderStorage.Create(newOrder);
            this.DialogResult = true;
        }
    }
}
