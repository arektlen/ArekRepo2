using System.Windows;
using OrdersRegistration.Statistics;
using MahApps.Metro.Controls;

namespace OrdersRegistration.WPF
{
    /// <summary>
    /// Interaction logic for SimpleStatistics.xaml
    /// </summary>
    public partial class SimpleStatistics : MetroWindow
    {
        Statistic1 statistic1 = new Statistic1();

        public SimpleStatistics()
        {
            InitializeComponent();
            LabelsFill();
        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Uzupełnianie label (wyświetlanie wyników statystyk)
        /// </summary>
        private void LabelsFill()
        {
            labelOrdersCountResult.Content = statistic1.GetOrdersCount();
            labelSumAllResult.Content = string.Format("{0:c}", statistic1.GetAllOrdersPrice());
            labelOrdersCountMonthResult.Content = statistic1.GetOrdersCountInCurrentMonth();
            labelSumMonthResult.Content = string.Format("{0:c}", statistic1.GetOrdersPriceInCurrentMonth());
            labelOrdersNonPaidResult.Content = statistic1.GetAllOrdersNonPaid();
            labelSumAllNonPaidResult.Content = string.Format("{0:c}", statistic1.GetAllOrdersPriceNonPaid());
            labelOrdersNonPaidInMonthResult.Content = statistic1.GetOrdersCountNonPaidInMonth();
            labelSumAllNonPaidInMonthResult.Content = string.Format("{0:c}", statistic1.GetOrdersPriceNonPaidInMonth());
        }

        /// <summary>
        /// Generuj PDF (Button)
        /// </summary>
        private void buttonGeneratePdf_Click(object sender, RoutedEventArgs e)
        {
            PdfExport pdfExport = new PdfExport();

            pdfExport.Statistic1ExportToPdf();
        }
    }
}
