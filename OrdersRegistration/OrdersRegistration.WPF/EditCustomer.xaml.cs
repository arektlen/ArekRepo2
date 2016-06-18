using System.Linq;
using System.Windows;
using System.Windows.Controls;
using OrdersRegistration.DbRepository;
using MahApps.Metro.Controls;

namespace OrdersRegistration.WPF
{
    /// <summary>
    /// Interaction logic for EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : MetroWindow
    {
        private IStorable<Model.Customer> _customerStorage;
        private Model.Customer _customerToEdit = null;

        /// <summary>
        /// Ctor
        /// </summary>
        public EditCustomer(IStorable<Model.Customer> customerStorage)
        {
            _customerStorage = customerStorage;

            InitializeComponent();
            comboBoxEditCustomer.ItemsSource = _customerStorage.Read();
        }

        /// <summary>
        /// Wybieranie zleceniodawcy do edycji
        /// </summary>
        private void comboBoxEditCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _customerToEdit = (Model.Customer)comboBoxEditCustomer.SelectedItem;
            textBoxEditCustomerName.Text = _customerToEdit.Name;
            textBoxEditCustomerMail.Text = _customerToEdit.Mail;
            textBoxEditCustomerPhone.Text = _customerToEdit.PhoneNumber;
        }

        /// <summary>
        /// Edycja zleceniodawcy (Button)
        /// </summary>
        private void buttonEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (_customerToEdit != null)
            {
                _customerStorage.Update(_customerToEdit);
                this.DialogResult = true;
                MessageBox.Show("Zmieniono!");
            }
        }

        /// <summary>
        /// Usuwanie zleceniodawcy (Button)
        /// </summary>
        private void buttonDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            OrderStorage orderStorage = new OrderStorage();

            if (!orderStorage.Read().Any(o => o.Customer.ID == _customerToEdit.ID))
            {
                MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz usunąć zleceniodawcę: " + _customerToEdit.Name + " ?", "Uwaga!", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    _customerStorage.Delete(_customerToEdit);
                    this.DialogResult = true;
                    MessageBox.Show("Usunięto!");
                }
            }
            else
            {
                MessageBox.Show("Nie można usunąć zleceniodawcy, ponieważ ma on przypisane zlecenia!");
            }
        }

        /// <summary>
        /// Nowa nazwa edytowanego zleceniodawcy
        /// </summary>
        private void textBoxEditCustomerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            _customerToEdit.Name = textBoxEditCustomerName.Text;
        }

        /// <summary>
        /// Nowy mail edytowanego zleceniodawcy
        /// </summary>
        private void textBoxEditCustomerMail_TextChanged(object sender, TextChangedEventArgs e)
        {
            _customerToEdit.Mail = textBoxEditCustomerMail.Text;
        }

        /// <summary>
        /// Nowy numer telefonu edytowanego zlecniodawcy
        /// </summary>
        private void textBoxEditCustomerPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            _customerToEdit.PhoneNumber = textBoxEditCustomerPhone.Text;
        }
    }
}
