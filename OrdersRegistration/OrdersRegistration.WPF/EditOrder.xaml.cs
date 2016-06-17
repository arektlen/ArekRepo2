using System.Windows;
using System.Windows.Controls;
using OrdersRegistration.DbRepository;
using MahApps.Metro.Controls;

namespace OrdersRegistration.WPF
{
    /// <summary>
    /// Interaction logic for EditOrder.xaml
    /// </summary>
    public partial class EditOrder : MetroWindow
    {
        private Model.Order _newOrder = new Model.Order();
        private IStorable<Model.Order> _orderStorage;

        /// <summary>
        /// Ctor
        /// </summary>
        public EditOrder(Model.Order editOrder, IStorable<Model.Order> orderStorage)
        {
            _newOrder = editOrder;
            _orderStorage = orderStorage;

            InitializeComponent();
            
            SetToTextbox();
        }

        private void SetToTextbox()
        {
            CustomerStorage _customerStorage = new CustomerStorage();

            foreach (var i in _customerStorage.Read())
            {
                if (i.Name == _newOrder.Customer.Name)
                {
                    comboBoxSelectCustomer.Items.Insert(0, i);
                    comboBoxSelectCustomer.Text = i.Name;
                }
                else
                {
                    comboBoxSelectCustomer.Items.Add(i);
                }
            }

            textBoxEditOrdername.Text = _newOrder.Name;
            textBoxEditComments.Text = _newOrder.Comments;
            textBoxEditOrderPrice.Text = string.Format("{0:0.00}", _newOrder.Price);
            dateEditOrderPicker.SelectedDate = _newOrder.Date;
            checkBoxIsPaid.IsChecked = _newOrder.IsPaid;
        }

        private void comboBoxSelectCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _newOrder.Customer = (Model.Customer)comboBoxSelectCustomer.SelectedItem;
        }

        private void tbEditOrdername_TextChanged(object sender, TextChangedEventArgs e)
        {
            _newOrder.Name = textBoxEditOrdername.Text;
        }

        private void tbEditOrderPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal price;
            if (decimal.TryParse(textBoxEditOrderPrice.Text, out price))
            {
                _newOrder.Price = price;
            }
        }

        private void tbEditComments_TextChanged(object sender, TextChangedEventArgs e)
        {
            _newOrder.Comments = textBoxEditComments.Text;
        }

        private void dateEditOrderPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _newOrder.Date = dateEditOrderPicker.SelectedDate.Value;
        }

        private void checkBoxIsPaid_Click(object sender, RoutedEventArgs e)
        {
            _newOrder.IsPaid = checkBoxIsPaid.IsChecked.Value;
        }

        private void btnEditAddOrder_Click(object sender, RoutedEventArgs e)
        {
            _orderStorage.Update(_newOrder);
            this.DialogResult = true;
        }
    }
}
