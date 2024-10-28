using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductManagement2.Authentication;
using ProductManagement2.Models;

namespace ProductManagement2.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin")]
	[Route("Admin/HomeAdmin")]

	public class HomeAdminController : Controller
	{
		QuanLySanPhamContext db = new QuanLySanPhamContext();

		[Route("")]
		[Route("Index")]
		[Authentication]
		public IActionResult Index()
		{
			return View();
		}

		[Route("ProductsManager")]
		[Authentication]
		public IActionResult ProductsManager()
		{
			var products = db.Products.ToList();

			return View(products);
		}

		[Route("CatalogsManager")]
		[Authentication]
		public IActionResult CatalogsManager()
		{
			var catalogs = db.Catalogs.ToList();

			return View(catalogs);
		}

		[Route("AddProduct")]
		[HttpGet]
		[Authentication]
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

		[Route("EditProduct")]
		[HttpGet]
		[Authentication]
		public IActionResult EditProduct(int id)
        {
            var product = db.Products.Find(id);
            ViewBag.CatalogId = new SelectList(db.Catalogs.ToList(), "Id", "CatalogName", product.CatalogId);
            return View(product);
        }

		[Route("EditProduct")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProductsManager", "HomeAdmin");
            }

            return View(product);
        }

		[Route("DeleteProduct")]
		[HttpGet]
		public IActionResult DeleteProduct(int id)
		{
			TempData["Message"] = "";
			var product = db.Products.Find(id);
			if (product != null)
			{
				db.Products.Remove(product);
				db.SaveChanges();
				TempData["Message"] = "Product has been deleted!";
			}
			else
			{
				TempData["Message"] = "Product not found!";
			}
			return RedirectToAction("ProductsManager");
		}
	}
}
