using System.Collections.Generic;

/// <summary>
/// Describes key functionality for a data repository for a class with type T which has a primary key of type K
/// </summary>
/// <typeparam name="T">The type of the class the repository handles</typeparam>
/// <typeparam name="K">The primary key type of the repository's data objects</typeparam>
namespace Alpha.Interfaces.Interfaces {
    public interface IRespositoryBase<T, K> where T : class {
        IEnumerable<T> GetAll();
        T GetById(K id);
        int Add(T obj);
        void Update(T obj);
        void Delete(T obj);
        void DeleteById(K id);
    }
}
