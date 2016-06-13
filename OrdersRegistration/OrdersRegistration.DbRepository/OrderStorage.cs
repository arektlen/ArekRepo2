using System.Collections.Generic;
using System.Linq;

namespace OrdersRegistration.DbRepository
{
    public class OrderStorage : IStorable<Model.Order>
    {
        public void Create(Model.Order element)
        {
            using (Database1Entities context = new Database1Entities())
            {
                context.Orders.Add(new Order()
                {
                    Name = element.Name,
                    Comments = element.Comments,
                    Price = element.Price,
                    IsPaid = element.IsPaid,
                    Date = element.Date,
                    IdCustomer = element.Customer.ID
                });

                context.SaveChanges();
            }
        }

        public IEnumerable<Model.Order> Read()
        {
            List<Model.Order> orderList = new List<Model.Order>();

            using (Database1Entities context = new Database1Entities())
            {
                Mapper mapper = new Mapper();

                foreach (var i in (context.Orders.ToList()))
                { 
                    orderList.Add(mapper.MapToModelOrder(i));
                }
            }

            return orderList;
        }

        public void Update(Model.Order element)
        {
            using (Database1Entities context = new Database1Entities())
            {
                var elementToUpdate = context.Orders.SingleOrDefault(o => o.Id == element.ID);

                elementToUpdate.Name = element.Name;
                elementToUpdate.Comments = element.Comments;
                elementToUpdate.Price = element.Price;
                elementToUpdate.IsPaid = element.IsPaid;
                elementToUpdate.Date = element.Date;
                elementToUpdate.IdCustomer = element.Customer.ID;
                    
                context.SaveChanges();  
            }
        }

        public void Delete(Model.Order element)
        {
            using (Database1Entities context = new Database1Entities())
            {
                var elementToDelete = context.Orders.SingleOrDefault(o => o.Id == element.ID);

                context.Orders.Remove(elementToDelete);
                context.SaveChanges();
            }
        }
    }
}

