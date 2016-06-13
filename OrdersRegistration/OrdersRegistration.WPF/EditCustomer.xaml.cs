using System.Linq;
using System.Windows;
using System.Windows.Controls;
using OrdersRegistration.DbRepository;

namespace OrdersRegistration.WPF
{
    /// <summary>
    /// Interaction logic for EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : Window
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
            textBoxEditCustomer.Text = _customerToEdit.Name;
        }

        /// <summary>
        /// Nowa nazwa edytowanego zleceniodawcy
        /// </summary>
        private void textBoxEditCustomer_TextChanged(object sender, TextChangedEventArgs e)
        {
            _customerToEdit.Name = textBoxEditCustomer.Text;
        }

        /// <summary>
        /// Edycja zleceniodawcy
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
        /// Usuwanie zleceniodawcy
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
    }
}
