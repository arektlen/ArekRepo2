using System.Windows;
using MahApps.Metro.Controls;

namespace OrdersRegistration.WPF
{
    /// <summary>
    /// Interaction logic for AboutApplication.xaml
    /// </summary>
    public partial class AboutApplication : MetroWindow
    {
        /// <summary>
        /// ctor
        /// </summary>
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
