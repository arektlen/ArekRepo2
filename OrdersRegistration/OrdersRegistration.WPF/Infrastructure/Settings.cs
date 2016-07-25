using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersRegistration.WPF
{
    public class Settings
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public OrdersCount OrdersCount { get; set; }

        public OrdersCount ordersAll = new OrdersCount() { Count = 0, Text = "Wyświetl wszystkie" };
        public OrdersCount orders10 = new OrdersCount() { Count = 1, Text = "10" }; //TODO: zmienić na poprawne wartości
        public OrdersCount orders20 = new OrdersCount() { Count = 2, Text = "20" };
        public OrdersCount orders30 = new OrdersCount() { Count = 3, Text = "30" };
        public OrdersCount orders40 = new OrdersCount() { Count = 4, Text = "40" };

        public void DefaultSettings()
        {
            DateFrom = DateTime.Today.AddMonths(-1);
            DateTo = DateTime.Today.AddMonths(1);
            OrdersCount = orders20;
        }
    }
}
