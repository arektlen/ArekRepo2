using System;
using System.Collections.Generic;
using System.Linq;

namespace OrdersRegistration.DbRepository
{
    public class OrderListFilter
    {
        public IEnumerable<Model.Order> GetOrderListDateFromTo(DateTime dateFrom, DateTime dateTo, int ordersCount)
        {
            List<Model.Order> list = new List<Model.Order>();

            using (Database1Entities context = new Database1Entities())
            {
                var dbList = context.Orders.Where(o => o.Date >= dateFrom && o.Date <= dateTo).OrderByDescending(o => o.Date).ThenByDescending(o => o.Id).Take(ordersCount);

                Mapper map = new Mapper();
                foreach (var i in dbList)
                {
                    var order = map.MapToModelOrder(i);
                    list.Add(order);
                }
                return list;
            }
        }

        public IEnumerable<Model.Order> GetOrderListDateFromTo(DateTime dateFrom, DateTime dateTo, int ordersCount, Model.Customer customer)
        {
            List<Model.Order> list = new List<Model.Order>();

            using (Database1Entities context = new Database1Entities())
            {
                var dbList = context.Orders.Where(o => o.Date >= dateFrom && o.Date <= dateTo && o.IdCustomer == customer.ID).OrderByDescending(o => o.Date).ThenByDescending(o => o.Id).Take(ordersCount);

                Mapper map = new Mapper();
                foreach (var i in dbList)
                {
                    var order = map.MapToModelOrder(i);
                    list.Add(order);
                }
                return list;
            }
        }
    }
}
