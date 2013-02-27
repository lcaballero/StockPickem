using LucidEdge.DataMapping;
using LucidEdge.DataMapping.Samples.SqlScripts;
using StockPickem.Models;
using StockPickem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockPickem.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index(string msg)
        {
			var doc = new DefaultDocument()
			{
				PageView = (new Admin_Page() { Msg = msg }).ToHtml()
			};

			return
			Content(doc.ToHtml().ToString());
        }

		public ActionResult CreateStockPicksTable()
		{
			Requests.DropTable("DROP TABLE IF EXISTS stock_picks");

			var status = Requests.Create(UserScripts.Create_Stock_Picks_Table);

			return RedirectToAction("Index", new { msg = string.Format("'stock_picks' table created with status {0}", status) });
		}

		public ActionResult InsertTestPicks()
		{
			var model = new InsertTestPicks_Model();
			model.Run();

			return RedirectToAction("Index", new { msg = "Test data was inserted into 'stock_picks'" });
		}

		public ActionResult UserPicks()
		{
			var model = new UserPicks_Page_Model();
			model.Init();

			var doc = new DefaultDocument()
			{
				PageView = (new UserPicks_Page() { Model = model}).ToHtml()
			};

			return
			Content(doc.ToHtml().ToString());
		}
    }
}
