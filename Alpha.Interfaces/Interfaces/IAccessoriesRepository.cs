using Alpha.Infrastructure.ViewModels;
using System.Collections.Generic;

namespace Alpha.Interfaces.Interfaces {
    public interface IAccessoriesRepository {   //: IRespositoryBase<Accessories, int> {

		IEnumerable<AccessoriesSummary> GetAll();
		AccessoriesDetails GetById(int id);
		int Add(AccessoriesDetails obj);
		void Update(AccessoriesDetails obj);
		void Delete(AccessoriesDetails obj);
		void DeleteById(int id);
	}
}
