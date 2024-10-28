using Microsoft.AspNetCore.Mvc;
using ProductManagement2.Models;

namespace ProductManagement2.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin")]
	[Route("Admin/HomeAdmin")]

	public class HomeAdminController : Controller
	{
		QuanLySanPhamContext db = new QuanLySanPhamContext();

		[Route("Index")]
		public IActionResult Index()
		{
			return View();
		}

		[Route("ProductsManager")]
		public IActionResult ProductsManager()
		{
			var products = db.Products.ToList();

			return View(products);
		}

		[Route("CatalogsManager")]
		public IActionResult CatalogsManager()
		{
			var catalogs = db.Catalogs.ToList();

			return View(catalogs);
		}
	}
}
