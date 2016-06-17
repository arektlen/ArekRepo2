using System.Windows;
using OrdersRegistration.DbRepository;
using MahApps.Metro.Controls;

namespace OrdersRegistration.WPF
{
    /// <summary>
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : MetroWindow
    {
        private IStorable<Model.Customer> _customerStorage;
        private Model.Customer newCustomer = new Model.Customer();

        public AddCustomer(IStorable<Model.Customer> customerStorage)
        {
            _customerStorage = customerStorage;
            InitializeComponent();
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            newCustomer.Name = tBAddCustomer.Text;
            _customerStorage.Create(newCustomer);
            this.DialogResult = true;
        }
    }
}
