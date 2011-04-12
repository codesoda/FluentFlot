using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeSoda.FluentFlot;
using NUnit.Framework;

namespace FluentFlot.Tests
{
	[TestFixture]
	public class ChartTests
	{

		[Test]
		public void EmptyChartTest()
		{
			var chart = new FlotChart("test");
		}

		[Test]
		public void BasicChartTest()
		{
			var chart = new FlotChart("test");
			chart.ToJson();
		}

		[Test]
		public void Test1()
		{
			var chart = new FlotChart("test")
				.AddSeries( options => options.Lines( lines => lines.Fill(true).LineWidth(3)) )
				.AddSeries(options => options.Lines(lines => lines.Fill(true).LineWidth(3)))
				.Options( options => options
					.Lines( lines => lines
						.Fill(true)
						.FillColor("#222222")
					)
				);

			string json = chart.ToJson();
		}



	}
}
