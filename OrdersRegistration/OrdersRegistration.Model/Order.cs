using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OrdersRegistration.Model
{
    public class Order
    {
        public delegate void IsPaidHandler(object sender, EventArgs e);
        public event IsPaidHandler IsPaidEvent;

        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        public decimal Price { get; set; }
        public Customer Customer { get; set; }
        private bool _isPaid;

        public bool IsPaid
        {
            get { return _isPaid; }
            set
            {
                _isPaid = value;
                if (IsPaidEvent != null)
                {
                    IsPaidEvent(this, EventArgs.Empty);
                } 
            }
        }  
    }
}
