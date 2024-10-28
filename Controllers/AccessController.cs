using Microsoft.AspNetCore.Mvc;
using ProductManagement2.Models;

namespace ProductManagement2.Controllers
{
	public class AccessController : Controller
	{
		QuanLySanPhamContext db = new QuanLySanPhamContext();

		[HttpGet]
		public IActionResult Login()
		{
			if (HttpContext.Session.GetString("Username") == null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpPost]
		public IActionResult Login(User user)
		{
			if (HttpContext.Session.GetString("Username") == null)
			{
				var obj = db.Users.Where(a => a.Username.Equals(user.Username) && a.PasswordHash.Equals(user.PasswordHash)).FirstOrDefault();
				if (obj != null)
				{
					HttpContext.Session.SetString("Username", obj.Username);
					HttpContext.Session.SetString("Role", obj.Role);
					if (obj.Role == "Admin")
					{
						return RedirectToAction("ProductsManager", "Admin");
					}
					else
					{
						return RedirectToAction("Index", "Home");
					}
				}
				else
				{
					ViewBag.error = "Invalid Account";
					return View();
				}
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}

		}
	}
}
