using System.Collections.Generic;

namespace OrdersRegistration.DbRepository
{
    /// <summary>
    /// CRUD Interface
    /// </summary>
    public interface IStorable<T>
    {
        void Create(T element);
        IEnumerable<T> Read();
        void Update(T element);
        void Delete(T element);
    }
}