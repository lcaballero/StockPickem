using StockPickem.Models;
using StockPickem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockPickem.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

		//public ActionResult Index()
		//{
		//	return View();
		//}

		public ActionResult Home()
		{
			Response.Write("<!DOCTYPE html>");
			var doc = new DefaultDocument()
			{
				PageView = new Home_Page().ToHtml()
			};
	
			return Content(doc.ToHtml().ToString());
		}

		public ActionResult Register()
		{
			Response.Write("<!DOCTYPE html>");

			var doc = new DefaultDocument()
			{
				PageView = new Register_Page().ToHtml()
			};

			doc.Scripts.Add("Content/Scripts/Register.js");

			return Content(doc.ToHtml().ToString());
		}

		public ActionResult SaveUserRegistration()
		{
			var user_name = Request.Params["email"];
			var user_pw = Request.Params["pw"];

			var model = new Register_Model();
			model.Init(user_name, 1, user_pw);

			return Json(
				new {
					Status = model.Status,
					StatusMsg = model.StatusMsg
				});
		}

		public ActionResult SignIn()
		{
			//var model = new SignIn_Model();
			//model.CheckUserCredentials();

			Response.Write("<!DOCTYPE html>");
			var doc = new DefaultDocument()
			{
				PageView = new SignIn_Page().ToHtml()
			};

			doc.Scripts.Add("Content/Scripts/SignIn.js");
			return Content(doc.ToHtml().ToString());
		}

		public ActionResult CheckLoginCredentials()
		{
			var model = new SignIn_Model();
			model.CheckUserCredentials();

			if (model.IsAuthenticated)
			{
				return Json(
				new
				{
					Status = 1,
					StatusMsg = "Success"
				});
			}
			else
			{
				return Json(
				new
				{
					Status = -1,
					StatusMsg = "Invalid user or password."
				});
			}
			
		}

		public ActionResult SignOut()
		{
			var model = new SignOut_Model();
			model.SignOut();

			return RedirectToAction("Home");
		}
    }
}
