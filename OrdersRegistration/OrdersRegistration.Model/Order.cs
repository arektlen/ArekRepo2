using System;

namespace OrdersRegistration.Model
{
    public class Order
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        public decimal Price { get; set; }
        public Customer Customer { get; set; }
        public bool IsPaid { get; set; }
    }
}
