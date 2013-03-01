using LucidEdge.DataMapping;
using Newtonsoft.Json;
using StockPickem.Data.Sql;
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

			var status = Requests.Create(SqlRequests.StockPicks.CreateStockPicksTable);

			return RedirectToAction("Index", new { msg = string.Format("'stock_picks' table created with status {0}", status) });
		}

		public ActionResult InsertTestPicks()
		{
			var model = new InsertTestPicks_Model();
			model.Run();

			return RedirectToAction("Index", new { msg = "Test data was inserted into 'stock_picks'" });
		}

		public ActionResult UserPerformance()
		{
			var model = new UserPerformance_Page_Model();
			model.Init();
			model.Load();

			var doc = new DefaultDocument()
			{
				PageView = (new UserPerformance_Page() { Model = model}).ToHtml()
			};

			doc.Scripts.Add("Content/Scripts/AdminUserPerformance.js");

			return
			Content(doc.ToHtml().ToString());
		}

		public ActionResult LoadUserPerformance(string username)
		{
			var model = new UserPerformance_Model();
			model.Init(username);
			model.Load();

			var view = new UserPerformance_MainModule() { Model = model };
			return Json(new
			{
				module = view.ToHtml().ToString(),
				chartData = model.ChartData.ChartData,
				symbols = model.Symbols
			});
		}

		public ActionResult LoadPerformanceChart(string symbol, string username)
		{
			PerformanceChart_Model PerformaceChart = new PerformanceChart_Model() { Symbol = symbol, UserName = username };
			PerformaceChart.Init();
			PerformaceChart.Load();

			return Json(new
			{
				chartData = PerformaceChart.ChartData
			});
		}
    }
}
