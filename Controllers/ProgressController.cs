using StockPickem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockPickem.Controllers
{
    public class ProgressController : Controller
    {
        //
        // GET: /Progress/

        public ActionResult Index()
        {
            return RedirectToAction("MyProgress");
        }

		public ActionResult MyProgress()
		{
			Response.Write("<!DOCTYPE html>");
			var doc = new DefaultDocument()
			{
				PageView = new Progress_Page().ToHtml()
			};

			doc.Scripts.Add("Content/Scripts/ProgressChart.js");
			return Content(doc.ToHtml().ToString());
		}

    }
}
