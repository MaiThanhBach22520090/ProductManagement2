using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

		[Route("AddProduct")]
		[HttpGet]
		public IActionResult AddProduct()
        {
			ViewBag.CatalogId = new SelectList(db.Catalogs.ToList(), "Id", "CatalogName");
            return View();
        }

		[Route("AddProduct")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddProduct(Product product)
        {
			if (ModelState.IsValid)
			{
				db.Products.Add(product);
				db.SaveChanges();
				return RedirectToAction("ProductsManager");
			}

			return View(product);
        }
	}
}
