using System.Linq;
using System.Windows;
using System.Windows.Controls;
using OrdersRegistration.DbRepository;
using MahApps.Metro.Controls;
using OrdersRegistration.Validation;

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
            if (textBoxEditCustomerName.Text != "")
            {
                _customerStorage.Update(_customerToEdit);
                this.DialogResult = true;
                MessageBox.Show("Dane zostały zaktualizowane!", "Informacja");
            }
            else
            {
                MessageBox.Show("Musisz podać nazwę Zleceniodawcy!", "Uwaga!");
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
                MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz usunąć zleceniodawcę: " + _customerToEdit.Name + " ?", "Uwaga!", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    _customerStorage.Delete(_customerToEdit);
                    this.DialogResult = true;
                    MessageBox.Show("Usunięto!", "Informacja");
                }
            }
            else
            {
                MessageBox.Show("Nie można usunąć zleceniodawcy, ponieważ ma on przypisane zlecenia!", "Uwaga!");
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
        /// Nowy numer telefonu edytowanego zleceniodawcy
        /// </summary>
        private void textBoxEditCustomerPhone_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Validators.IsDigitValidation(textBoxEditCustomerPhone.Text))
            {
                _customerToEdit.PhoneNumber = textBoxEditCustomerPhone.Text;
            }
            else
            {
                MessageBox.Show("Musisz wpisać CYFRY!", "Uwaga!");
                textBoxEditCustomerPhone.Clear();
            }
        }
    }
}
