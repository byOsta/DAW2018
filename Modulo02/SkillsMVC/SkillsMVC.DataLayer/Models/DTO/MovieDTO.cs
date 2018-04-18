using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsMVC.DataLayer.Models.DTO
{
	public class MovieDTO
	{

		public MovieDTO()
		{
			Artists = new HashSet<ArtistDTO>();
		}

		public int MovieId { get; set; }

		public string Title { get; set; }

		public int? Director { get; set; }

		public int? Year { get; set; }

		public int? Vote { get; set; }

		public int Position { get; set; }

		public decimal? Rating { get; set; }

		public string Image { get; set; }

		public string Link { get; set; }

		public virtual ArtistDTO Artist { get; set; }

		public virtual ICollection<ArtistDTO> Artists { get; set; }

	}
}
