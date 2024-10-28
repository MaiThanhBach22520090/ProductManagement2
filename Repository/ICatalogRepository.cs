using ProductManagement2.Models;
using System.Collections;

namespace ProductManagement2.Repository
{
	public interface ICatalogRepository
	{
		Catalog Add(Catalog catalog);
		Catalog Update(Catalog catalog);
		Catalog Delete(Catalog catalog);
		Catalog Get(Catalog catalog);
		IEnumerable<Catalog> GetAll();

	}
}
