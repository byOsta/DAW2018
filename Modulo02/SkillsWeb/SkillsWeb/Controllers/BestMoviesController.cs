using Newtonsoft.Json;
using SkillsMVC.DataLayer.Models.DTO;
using SkillsWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SkillsWeb.Controllers
{
	public class BestMoviesController : Controller
	{
		MovieService service = new MovieService();


		/// <summary>
		/// Get all movies
		/// </summary>
		public async Task<ActionResult> Index()
		{

			var movies = await service.GetAsync<List<MovieDTO>>("http://localhost:44444/movies");

			return View("Index",
				movies
			);
		}
	}
}