using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsMVC.DataLayer.Models
{
	interface IUnitOfWork
	{
		IRepository<T> GetRepository<T>() where T : class;
		bool Save();
		Task<bool> SaveAsync();
		ValidationResult Validate();
		bool CheckDBExists();
	}
}
