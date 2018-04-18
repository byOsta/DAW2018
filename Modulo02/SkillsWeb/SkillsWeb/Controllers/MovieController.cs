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
    public class MovieController : Controller
    {
		// GET: Movie
		MovieService service = new MovieService();

		public async Task<ActionResult> Index(int movieId)
        {
			var movies = await service.GetAsync<MovieDTO>("http://localhost:44444/movies?id=" + movieId);

			return View("Index",
				movies
			);
		}

		public async Task<ActionResult> Delete(int movieId)
		{
			var movies = await service.DeleteAsync("http://localhost:44444/movies?id=" + movieId);

			return JavaScript("window.location = '../Home/Index'");
		}
	}
}