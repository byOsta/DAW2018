using SkillsMVC.DataLayer.Models.DTO;
using SkillsWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SkillsWeb.Controllers
{
	public class HomeController : Controller
	{
		MovieService service = new MovieService();

		public async Task<ActionResult> Index()
		{
			var movies = await service.GetAsync<List<MovieDTO>>("http://localhost:44444/movies");

			return View("Index",
				movies
			);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}