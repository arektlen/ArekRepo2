using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersRegistration.WPF
{
    public class Settings
    {
        public int DateFrom { get; set; }
        public int DateTo { get; set; }
        public OrdersCount OrdersCount { get; set; }

        public OrdersCount ordersAll = new OrdersCount() { Count = 0, Text = "Wyświetl wszystkie" };
        public OrdersCount orders10 = new OrdersCount() { Count = 10, Text = "10" }; 
        public OrdersCount orders20 = new OrdersCount() { Count = 20, Text = "20" };
        public OrdersCount orders30 = new OrdersCount() { Count = 30, Text = "30" };
        public OrdersCount orders40 = new OrdersCount() { Count = 40, Text = "40" };

        /// <summary>
        /// Ustawianie domyślnych wartości wyświetlania zamówień w MainWindow
        /// </summary>
        public void DefaultSettings()
        {
            DateFrom = -1;
            DateTo = 0;
            OrdersCount = ordersAll;
        }
    }
}
