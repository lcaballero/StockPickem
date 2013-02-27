using LucidEdge.Html;
using StockPickem.Models;
using StockPickem.Views.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockPickem.Views
{
	public class SignIn_Page : HtmlContainer
	{
		public SignIn_Model Model { get; set; }

		public SignIn_Page()
			: base("div#signin-page") {}

		public override IHtml ToHtml()
		{
			return Container.Add(
				new MainNav(),
				"div.container".Add(
					new SignIn_Module()
				)
			);
		}
	}
}