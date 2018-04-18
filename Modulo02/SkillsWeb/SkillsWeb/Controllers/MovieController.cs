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

		MovieService service = new MovieService();

		/// <summary>
		/// Get movie by id
		/// </summary>
		/// <param name="movieId">id</param>
		public async Task<ActionResult> Index(int movieId)
        {
			var movies = await service.GetAsync<MovieDTO>("http://localhost:44444/movies?id=" + movieId);

			return View("Index",
				movies
			);
		}

		/// <summary>
		/// Delete by id
		/// </summary>
		/// <param name="movieId">id to delete</param>
		public async Task<ActionResult> Delete(int movieId)
		{
			var movies = await service.DeleteAsync("http://localhost:44444/movies?id=" + movieId);

			return JavaScript("window.location = '../Home/Index'");
		}
	}
}