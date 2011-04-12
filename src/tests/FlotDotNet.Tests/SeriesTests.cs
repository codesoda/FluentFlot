
using CodeSoda.FluentFlot;
using NUnit.Framework;

namespace FluentFlot.Tests
{
	[TestFixture]
	public class SeriesTests
	{

		[Test]
		public void CanCreateSeries()
		{
			var series = new FlotSeries(null);
		}

		#region Add

		[Test]
		public void CanAddSinglePoint()
		{
			var series = new FlotSeries(null);
			series.Add(new FlotPoint(2, 3));
			Assert.AreEqual(1, series.Data.Count);
		}

		[Test]
		public void CanAddFromXy()
		{
			var series = new FlotSeries(null);
			series.Add(2, 3);
			Assert.AreEqual(1, series.Data.Count);
		}

		[Test]
		public void CanAddEnumerablePoints()
		{
			var points = new[] {
				new FlotPoint(1,1),
				new FlotPoint(2,2),
				new FlotPoint(3,3)
			};

			var series = new FlotSeries(null);
			series.Add(points);
			Assert.AreEqual(3, series.Data.Count);
		}

		[Test]
		public void CanAddEnumerableFuncPoints()
		{
			var indexes = new [] {1,2,3,4,5};

			var series = new FlotSeries(null);
			series.Add(indexes, x=> new FlotPoint(x,x));
			Assert.AreEqual(5, series.Data.Count);
		}

		#endregion

		//[Test]
		//public void CanSetColor()
		//{
		//    var series = new FlotSeries(null).Color("red");
		//    string json = series.ToJson();
		//    Assert.AreEqual("{color:\"red\"}", json);
		//}

		//[Test]
		//public void CanSetLabel()
		//{
		//    var series = new FlotSeries(null).Label("label");
		//    string json = series.ToJson();
		//    Assert.AreEqual("{label:\"label\"}", json);
		//}

		//[Test]
		//public void CanSetXAxis()
		//{
		//    var series = new FlotSeries(null).XAxis(1);
		//    string json = series.ToJson();
		//    Assert.AreEqual("{xaxis:1}", json);
		//}

		//[Test]
		//public void CanSetYAxis()
		//{
		//    var series = new FlotSeries(null).YAxis(2);
		//    string json = series.ToJson();
		//    Assert.AreEqual("{yaxis:2}", json);
		//}

		//[Test]
		//public void CanSetClickable()
		//{
		//    var series = new FlotSeries(null).Clickable(true);
		//    string json = series.ToJson();
		//    Assert.AreEqual("{clickable:true}", json);
		//}

		//[Test]
		//public void CanSetHoverable()
		//{
		//    var series = new FlotSeries(null).Hoverable(false);
		//    string json = series.ToJson();
		//    Assert.AreEqual("{hoverable:false}", json);
		//}

		//[Test]
		//public void CanSetShadowSize()
		//{
		//    var series = new FlotSeries(null).ShadowSize(3);
		//    string json = series.ToJson();
		//    Assert.AreEqual("{shadowSize:3}", json);
		//}

		//[Test]
		//public void CanSetSeriesLineOptions()
		//{
		//    var series = new FlotSeries(null)
		//        .Lines(lo => lo
		//            .FillColor("#222")
		//            .Show(true)
		//        )
		//        .ShadowSize(3);

		//    var json = series.ToJson();
		//}

		#region json

		[Test]
		public void CanGetJsonWhenNotFieldsOrPoints()
		{
			var series = new FlotSeries(null);
			string json = series.ToJson();
			Assert.AreEqual("null", json);
		}

		#endregion

		#region .Chart

		[Test]
		public void CheckSeriesDotChart()
		{
			var chart = new FlotChart("test");
			var series = new FlotSeries(chart);
			Assert.AreEqual(chart, series.Chart);
		}

		#endregion
	}
}
