using System;
using System.Linq;
using OrdersRegistration.DbRepository;

namespace OrdersRegistration.Statistics
{
    public class Statistic1 //TODO: !!!!! Zrobić warunek przy generowaniu raportu na wypadek zerowych wartości !!!!!!
    {
        private static DateTime today = DateTime.Today;
        private DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);

        /// <summary>
        /// Ogólna liczba zleceń
        /// </summary>
        public int GetOrdersCount()
        {
            using (Database1Entities context = new Database1Entities())
            {
                return context.Orders.Count();               
            }        
        }

        /// <summary>
        /// Łączna kwota wszystkich zleceń
        /// </summary>
        public decimal GetAllOrdersPrice()
        {
            using (Database1Entities context = new Database1Entities())
            {
                return context.Orders.Sum(o => (decimal?)o.Price) ?? 0;
            }
        }

        /// <summary>
        /// Liczba zleceń nieopłaconych
        /// </summary>
        public int GetAllOrdersNonPaid()
        {
            using (Database1Entities context = new Database1Entities())
            {
                return context.Orders.Where(o => o.IsPaid == false).Count();
            }
        }

        /// <summary>
        /// Łączna kwota za zlecenia nieopłacone
        /// </summary>
        public decimal GetAllOrdersPriceNonPaid()
        {
            using (Database1Entities context = new Database1Entities())
            {
                return context.Orders.Where(o => o.IsPaid == false).Sum(o => (decimal?)o.Price) ?? 0;
            }
        }

        /// <summary>
        /// Liczba zleceń w bieżącym miesiącu
        /// </summary>
        public int GetOrdersCountInCurrentMonth()
        {
            using (Database1Entities context = new Database1Entities())
            {
                return context.Orders.Where(o => o.Date <= today && o.Date >= firstDayOfMonth).Count();
            }
        }

        /// <summary>
        /// Łączna kwota zleceń w bieżącym miesiącu
        /// </summary>
        public decimal GetOrdersPriceInCurrentMonth()
        {
            using (Database1Entities context = new Database1Entities())
            {
                return context.Orders.Where(o => o.Date <= today && o.Date >= firstDayOfMonth).Sum(o => (decimal?)o.Price) ?? 0;
            }
        }

        /// <summary>
        /// Liczba zleceń nieopłaconych w bieżącym miesiącu
        /// </summary>
        public int GetOrdersCountNonPaidInMonth()
        {
            using (Database1Entities context = new Database1Entities())
            {
                return context.Orders.Where(o => o.Date <= today && o.Date >= firstDayOfMonth && o.IsPaid == false).Count();
            }
        }

        /// <summary>
        /// Łączna kwota zleceń nieopłaconych w bieżącym miesiącu
        /// </summary>
        public decimal GetOrdersPriceNonPaidInMonth()
        {
            using (Database1Entities context = new Database1Entities())
            {
                return context.Orders.Where(o => o.Date <= today && o.Date >= firstDayOfMonth && o.IsPaid == false).Sum(o => (decimal?)o.Price) ?? 0;
            }
        }
    }
}
