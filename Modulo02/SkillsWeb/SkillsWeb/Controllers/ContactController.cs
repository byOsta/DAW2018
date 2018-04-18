using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkillsWeb.Controllers
{
    public class ContactController : Controller
    {
        /// <summary>
		/// Show index
		/// </summary>
        public ActionResult Index()
        {
            return View();
        }

		/// <summary>
		/// Send message and move to other page
		/// </summary>
		public ActionResult SendMessage() {
			return View("Enviado");
		}
    }
}