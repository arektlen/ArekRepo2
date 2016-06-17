using System.Windows;
using OrdersRegistration.DbRepository;
using MahApps.Metro.Controls;

namespace OrdersRegistration.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow mainWindow = new MainWindow(new OrderStorage(), new CustomerStorage());
            mainWindow.Show();
        }      
    }
}
