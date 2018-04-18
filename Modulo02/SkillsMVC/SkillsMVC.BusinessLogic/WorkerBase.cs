using SkillsMVC.BusinessLogic.Interfaces;
using SkillsMVC.DataLayer.Factories;
using SkillsMVC.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsMVC.BusinessLogic.Workers
{
	public class WorkerBase : IWorkerBase
	{
		public UnitOfWork<SkillsContext> uow = new UnitOfWork<SkillsContext>(new SkillsContextFactory());
		public WorkerBase()
		{

		}
	}
}
