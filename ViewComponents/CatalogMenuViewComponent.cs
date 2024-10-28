using ProductManagement2.Models;
using Microsoft.AspNetCore.Mvc;
using ProductManagement2.Repository;

namespace ProductManagement2.ViewComponents
{
	public class CatalogMenuViewComponent: ViewComponent
	{
		private readonly ICatalogRepository _catalogRepository;

		public CatalogMenuViewComponent(ICatalogRepository catalogRepository)
		{
			_catalogRepository = catalogRepository;
		}

		public IViewComponentResult Invoke()
		{
			var catalog = _catalogRepository.GetAll().OrderBy(x => x.Id);
			return View(catalog);
		}
	}
}
