using SkillsMVC.BusinessLogic.Workers;
using SkillsMVC.DataLayer.Models;
using SkillsMVC.DataLayer.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SkillsMVC.API.Controllers
{
	[Route("movies")]
	public class MovieController : ApiController
	{

		#region Properties
		private MovieCW _movieCW = new MovieCW();
		#endregion

		// GET api/values
		public IEnumerable<MovieDTO> Get()
		{

			List<Movie> movies = _movieCW.GetAll();

			var listMin  = _movieCW.Minify(movies).ToList();

			return listMin;
		}

		// GET api/values/5
		public MovieDTO Get(int id)
		{
			return _movieCW.GetById(id);
		}

		// POST api/values
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
			_movieCW.Delete(id);
		}
	}
}
