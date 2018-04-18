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

		/// <summary>
		/// GET movies
		/// </summary>
		/// <returns>IEnumerable<MovieDTO></returns>
		public IEnumerable<MovieDTO> Get()
		{
		
			List<Movie> movies = _movieCW.GetAll();

			var listMin  = _movieCW.Minify(movies).ToList();

			return listMin;
		}
		/// <summary>
		/// GET movies?id={id}
		/// </summary>
		/// <param name="id">Id to obtain</param>
		/// <returns>MovieDTO</returns>
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

		/// <summary>
		/// DELETE api/values/5
		/// </summary>
		/// <param name="id">id to delete</param>
		public void Delete(int id)
		{
			_movieCW.Delete(id);
		}
	}
}
