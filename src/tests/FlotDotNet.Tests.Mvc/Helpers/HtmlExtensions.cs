using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeSoda.FluentFlot;

namespace FlotDotNet.Tests.Mvc.Helpers
{
	public static class HtmlExtensions
	{

		public static string Flot(this HtmlHelper html, string placeholder, System.Action<FlotChart> populateChart)
		{
			var chart = new FlotChart(placeholder);
			populateChart(chart);
			return chart.ToJson();
		}
	}
}
