using System.Collections.Generic;
using Alpha.Infrastructure.ViewModels;

namespace Alpha.Interfaces.Interfaces {
    public interface IAddonsRepository {//: IRespositoryBase<Addons, int> {
        IEnumerable<AddonsDetails> GetAll();
        AddonsDetails GetById(int id);
        int Add(AddonsDetails obj);
        void Update(AddonsDetails obj);
        void Delete(AddonsDetails obj);
        void DeleteById(int id);
    }
}
