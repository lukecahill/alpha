using System.Collections.Generic;

/// <summary>
/// Describes key functionality for a data repository for a class with type T which has a primary key of type K
/// </summary>
/// <typeparam name="S">The summary details which will be returned</typeparam>
/// <typeparam name="D">The detailed object</typeparam>
/// <typeparam name="C">The create binding model</typeparam>
/// <typeparam name="U">The update binding model</typeparam>
/// <typeparam name="L">The delete binding model</typeparam>
/// <typeparam name="I">The ID to delete</typeparam>
namespace Alpha.Interfaces.Interfaces {
    public interface IRespositoryBase<S, D, C, U, L, I> {
        IEnumerable<S> GetAll();
        D GetById(I id);
        C Add(C obj);
        void Update(U obj);
        void Delete(L obj);
        void DeleteById(I id);
    }
}
