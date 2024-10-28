using ProductManagement2.Models;

namespace ProductManagement2.Repository
{
	public class CatalogRepository : ICatalogRepository
	{
		private readonly QuanLySanPhamContext _context;

		public CatalogRepository(QuanLySanPhamContext context)
		{
			_context = context;
		}

		public Catalog Add(Catalog catalog)
		{
			_context.Catalogs.Add(catalog);
			_context.SaveChanges();
			return catalog;
		}

		public Catalog Delete(Catalog catalog)
		{
			throw new NotImplementedException();
		}

		public Catalog Get(Catalog catalog)
		{
			return _context.Catalogs.Find(catalog);
		}

		public IEnumerable<Catalog> GetAll()
		{
			return _context.Catalogs;
		}

		public Catalog Update(Catalog catalog)
		{
			_context.Update(catalog);
			_context.SaveChanges();
			return catalog;
		}
	}
}
