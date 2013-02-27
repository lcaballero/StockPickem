using LucidEdge.Html;
using StockPickem.Views.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockPickem.Views
{
	public class DefaultDocument : HtmlContainer
	{
		public DefaultDocument()
			: base("html") { }

		public IHtml PageView { get; set; }

		private List<string> _Scripts {get; set;}
		public List<string> Scripts {get {
			return _Scripts == null 
				? (_Scripts = new List<string>())
				: _Scripts;
		}}

		public override IHtml ToHtml()
		{
			IHtml body = "body".Add();

			body.Add(
				"body".Add(
					PageView,
					string.Format("<script src=\"{0}\"></script>",
						"http://code.jquery.com/jquery.js"),
					string.Format("<script src=\"{0}{1}\"></script>",
						VirtualPathUtility.ToAbsolute("~/"), "Content/bootstrap/js/bootstrap.js"),
					string.Format("<script src=\"{0}{1}\"></script>",
						VirtualPathUtility.ToAbsolute("~/"), "Content/Scripts/Highstock-1.2.5/js/highstock.js"),
					string.Format("<script src=\"{0}{1}\"></script>",
						VirtualPathUtility.ToAbsolute("~/"), "Content/Scripts/Highstock-1.2.5/js/modules/exporting.js")
				)
			);

			for (int i = 0; i < Scripts.Count; ++i)
			{
				body.Add(
					string.Format("<script src=\"{0}{1}\"></script>",
						VirtualPathUtility.ToAbsolute("~/"), Scripts[i])
				);
			}

			Container.Add(
				"head".Add(
					"title".Add("Stock Pick'em"),
					"meta".Attr("name", "viewport", "content", "width=device-width", "initial-scale", "1.0"),
					string.Format("<link href=\"{0}{1}\" rel=\"stylesheet\" type=\"text/css\">",
						VirtualPathUtility.ToAbsolute("~/"), "Content/bootstrap/css/bootstrap.css"),
					string.Format("<link href=\"{0}{1}\" rel=\"stylesheet\" media=\"screen\">",
						VirtualPathUtility.ToAbsolute("~/"), "Content/bootstrap/css/bootstrap-responsive.css"),
					string.Format("<link href=\"{0}{1}\" rel=\"stylesheet\" media=\"screen\">",
						VirtualPathUtility.ToAbsolute("~/"), "Content/Styles/Main.css")
				),
				body
			);

			return Container;
		}
	}
}