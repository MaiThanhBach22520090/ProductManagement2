using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ProductManagement2.Models;
using System.Diagnostics;
using X.PagedList;

namespace ProductManagement2.Controllers
{
	public class HomeController : Controller
	{
		QuanLySanPhamContext db = new QuanLySanPhamContext();

		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index(int? page)
		{
			int pageSize = 8;
			int pageNumber = page == null || page < 0 ? 1 : page.Value;

			var listSanpham = db.Products.AsNoTracking().OrderBy(x => x.Id);

			PagedList<Product> list = new PagedList<Product>(listSanpham, pageNumber, pageSize);

			return View(list);
		}

		public IActionResult ProductsByCatalog(int CatalogID, int? page)
		{
			int pageSize = 8;
			int pageNumber = page == null || page < 0 ? 1 : page.Value;
			var products = db.Products.AsNoTracking().Where(x => x.CatalogId == CatalogID).OrderBy(x => x.Id);
			PagedList<Product> list = new PagedList<Product>(products, pageNumber, pageSize);

			ViewBag.CatalogID = CatalogID;
			return View(list);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
