using System.Collections.Generic;
using System.Linq;

namespace OrdersRegistration.DbRepository
{
    public class CustomerStorage : IStorable<Model.Customer>
    {
        public void Create(Model.Customer element)
        {
            using (Database1Entities context = new Database1Entities())
            {
                context.Customers.Add(new Customer()
                {
                    Name = element.Name,
                    Mail = element.Mail,
                    PhoneNumber = element.PhoneNumber                  
                });

                context.SaveChanges();
            }
        }

        public IEnumerable<Model.Customer> Read()
        {
            List<Model.Customer> customerList = new List<Model.Customer>();

            using (Database1Entities context = new Database1Entities())
            {
                Mapper mapper = new Mapper();

                foreach (var i in context.Customers.ToList())
                {
                    customerList.Add(mapper.MapToModelCustomer(i));
                }
            }

            return customerList;
        }

        public void Update(Model.Customer element)
        {
            using (Database1Entities context = new Database1Entities())
            {
                var elementToUpdate = context.Customers.SingleOrDefault(o => o.Id == element.ID);

                elementToUpdate.Name = element.Name;
                elementToUpdate.Mail = element.Mail;
                elementToUpdate.PhoneNumber = element.PhoneNumber;
                context.SaveChanges();
            }
        }

        public void Delete(Model.Customer element)
        {
            using (Database1Entities context = new Database1Entities())
            {
                var elementToRemove = context.Customers.SingleOrDefault(o => o.Id == element.ID);
                context.Customers.Remove(elementToRemove);
                context.SaveChanges(); 
            }
        }
    }
}