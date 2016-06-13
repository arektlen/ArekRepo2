using System.Windows;

namespace OrdersRegistration.WPF
{
    /// <summary>
    /// Interaction logic for AboutApplication.xaml
    /// </summary>
    public partial class AboutApplication : Window
    {
        public AboutApplication()
        {
            InitializeComponent();
        }

        private void buttonOkAboutApplication_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
