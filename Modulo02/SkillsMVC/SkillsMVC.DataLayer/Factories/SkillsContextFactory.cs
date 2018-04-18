using SkillsMVC.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsMVC.DataLayer.Factories
{
	public class SkillsContextFactory : IDbContextFactory<SkillsContext>
	{
		public SkillsContext Create()
		{
			SkillsContext context = new SkillsContext();
			if (!context.Database.Exists())
			{
				string err = "err";
			}
			return context;
		}
	}
}
