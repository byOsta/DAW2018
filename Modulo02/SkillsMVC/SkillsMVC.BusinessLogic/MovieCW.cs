using Contoso.NLayer.DataLayer.Models;
using SkillsMVC.DataLayer.Models;
using SkillsMVC.DataLayer.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsMVC.BusinessLogic.Workers
{
	public class MovieCW : WorkerBase
	{
		#region Properties
		private IRepository<Movie> _movieRepository { get; set; }
		#endregion

		#region Constructor
		public MovieCW()
		{
			this._movieRepository = uow.GetRepository<Movie>();
		}
		#endregion

		#region Methods
		public void Delete(int id)
		{
			//var movie = _movieRepository.FindById(id);

			_movieRepository.Delete(id);

			uow.Save();
		}


		public List<Movie> GetAll()
		{
			List<Movie> listPersons = _movieRepository.FindAll(null).ToList();

			
			return listPersons;
		}

		public MovieDTO GetById(int id)
		{
			List<MovieDTO> choosen = this.Minify(_movieRepository.FindAll(null).ToList()).ToList();
			var movie = choosen.Single(x => x.MovieId == id);
			return movie;
		}
		#endregion 

		public MovieDTO Minify(Movie model) {

			MovieDTO minified = new MovieDTO() {
				MovieId = model.MovieId,
				Title = model.Title,
				Director = model.Director,
				Year = model.Year,
				Vote = model.Vote,
				Rating = decimal.Round((decimal)model.Rating, 2, MidpointRounding.AwayFromZero),
				Image = model.Image,
				Link = model.Link,
				Artist = this.Minify(model.Artist),
				Artists = this.Minify(model.Artists)
			};

			return minified;
		}

		public ICollection<MovieDTO> Minify(ICollection<Movie> model)
		{
			List<MovieDTO> movieDTOs = new List<MovieDTO>();

			int count = 0;
			model.ToList().ForEach(x => {
				count++;
				var movie = this.Minify(x);
				movie.Position = count;
				movieDTOs.Add(movie);
			});

			return movieDTOs;
		}

		public ArtistDTO Minify(Artist model)
		{

			ArtistDTO minified = new ArtistDTO()
			{
				ArtistId = model.ArtistId,
				Name = model.Name
			};

			return minified;
		}

		public ICollection<ArtistDTO> Minify(ICollection<Artist> model)
		{
			List<ArtistDTO> artistDTOs = new List<ArtistDTO>();
			model.ToList().ForEach(x => artistDTOs.Add(this.Minify(x)));

			return artistDTOs;
		}

	}
}
