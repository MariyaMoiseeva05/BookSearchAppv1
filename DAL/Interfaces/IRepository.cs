
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(); // получение всех объектов
        T GetItem(object id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item, object id); // обновление объекта
        void Delete(object id); // удаление объекта по id
    }
}
