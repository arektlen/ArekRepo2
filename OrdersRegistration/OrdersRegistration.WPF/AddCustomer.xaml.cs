using System.Windows;
using OrdersRegistration.DbRepository;
using MahApps.Metro.Controls;
using OrdersRegistration.Validation;

namespace OrdersRegistration.WPF
{
    /// <summary>
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : MetroWindow
    {
        private IStorable<Model.Customer> _customerStorage;
        private Model.Customer newCustomer = new Model.Customer();

        /// <summary>
        /// ctor
        /// </summary>
        public AddCustomer(IStorable<Model.Customer> customerStorage)
        {
            _customerStorage = customerStorage;
            InitializeComponent();
        }

        /// <summary>
        /// Zapisanie nowego zleceniodawcy do bazy danych (Button)
        /// </summary>
        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (tBAddCustomerName.Text != "")
            {
                _customerStorage.Create(newCustomer);
                this.DialogResult = true;
                MessageBox.Show("Dodano nowego Zleceniodawcę!", "Informacja");
            }
            else
            {
                MessageBox.Show("Musisz podać nazwę Zleceniodawcy!", "Uwaga!");
            }        
        }

        /// <summary>
        /// Nazwa zleceniodawcy
        /// </summary>
        private void tBAddCustomerName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            newCustomer.Name = tBAddCustomerName.Text;
        }

        /// <summary>
        /// E-mail zleceniodawcy
        /// </summary>
        private void textBoxAddCustomerMail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Validators.MailValidation(textBoxAddCustomerMail.Text))
            {
                newCustomer.Mail = textBoxAddCustomerMail.Text;
            }
            else
            {
                MessageBox.Show("Podaj poprawny adres E-mail!", "Uwaga!");
                textBoxAddCustomerMail.Clear();                 
            }
        }

        /// <summary>
        /// Numer telefonu zleceniodawcy
        /// </summary>
        private void textBoxAddCustomerPhone_LostFocus(object sender, RoutedEventArgs e)
        {


            if (Validators.IsDigitValidation(textBoxAddCustomerPhone.Text))
            {
                newCustomer.PhoneNumber = textBoxAddCustomerPhone.Text;
            }
            else
            {
                MessageBox.Show("Musisz wpisać CYFRY!", "Uwaga!");
                textBoxAddCustomerPhone.Clear();
            }
        }
    }
}
