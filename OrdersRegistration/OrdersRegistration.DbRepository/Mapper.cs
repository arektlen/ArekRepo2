namespace OrdersRegistration.DbRepository
{
    public class Mapper
    {
        public Model.Customer MapToModelCustomer(DbRepository.Customer dbCustomer)
        {
            Model.Customer newCustomer = new Model.Customer();
            newCustomer.ID = dbCustomer.Id;
            newCustomer.Name = dbCustomer.Name;
            newCustomer.Mail = dbCustomer.Mail;
            newCustomer.PhoneNumber = dbCustomer.PhoneNumber;

            return newCustomer;
        }

        public Model.Order MapToModelOrder(DbRepository.Order dbOrder)
        {
            Model.Order order = new Model.Order();

            order.ID = dbOrder.Id;
            order.Name = dbOrder.Name;
            order.Date = dbOrder.Date;
            order.Customer = MapToModelCustomer(dbOrder.Customer);
            order.Comments = dbOrder.Comments;
            order.Price = dbOrder.Price;
            order.IsPaid = dbOrder.IsPaid;

            return order;
        }
    }
}
