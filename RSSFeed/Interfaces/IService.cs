using System.Collections.Generic;

namespace RSSFeed.Interfaces
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        void Update(T item);
    }
}
