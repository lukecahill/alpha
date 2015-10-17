using System.Collections.Generic;
using Alpha.Infrastructure.ViewModels;
using Alpha.Infratructure.BindingModels;

namespace Alpha.Interfaces.Interfaces {
    public interface IAddonsRepository {//: IRespositoryBase<Addons, int> {
        IEnumerable<AddonsDetails> GetAll();
        AddonsDetails GetById(int id);
        CreateAddonBindingModel Add(CreateAddonBindingModel obj);
        void Update(UpdateAddonBindingModel obj);
        void Delete(DeleteAddonBindingModel obj);
        void DeleteById(int id);
    }
}
