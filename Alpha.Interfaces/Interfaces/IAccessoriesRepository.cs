using Alpha.Infrastructure.ViewModels;
using System.Collections.Generic;
using Alpha.Infrastructure.BindingModels;

namespace Alpha.Interfaces.Interfaces {
    public interface IAccessoriesRepository {   //: IRespositoryBase<Accessories, int> {

		IEnumerable<AccessoriesSummary> GetAll();
		AccessoriesDetails GetById(int id);
		CreateAccessoriesBindingModels Add(CreateAccessoriesBindingModels obj);
		void Update(UpdateAccessoriesBindingModels obj);
		void Delete(DeleteAccessoriesBindingModels obj);
		void DeleteById(int id);
	}
}
