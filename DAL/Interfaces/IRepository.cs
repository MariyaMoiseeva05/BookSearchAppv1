
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(); // получение всех объектов
        T GetItem(int? id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item, int? id); // обновление объекта
        void Delete(int? id); // удаление объекта по id
    }
}
