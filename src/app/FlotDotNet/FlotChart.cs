
using System.Collections.Generic;

namespace CodeSoda.FluentFlot
{
	public delegate TResult Func<TResult>();
	public delegate TResult Func<T, TResult>(T arg);
	public delegate TResult Func<T1, T2, TResult>(T1 arg1, T2 arg2);
	public delegate bool Predicate<T>(T arg);
	public delegate void Action<T>(T arg);
	public delegate void Action<T1, T2>(T1 arg1, T2 arg2);

	public class FlotChart
	{
		public FlotChartOptions FlotChartOptions;
		public string PlaceHolder { get; private set; }
		public List<FlotSeries> Series { get; private set; }

		public FlotChart(string placeholder)
		{
			PlaceHolder = placeholder;
			Series = new List<FlotSeries>();
		}

		public void ToJson(JsonBuilder json)
		{
			// $.plot($("#placeholder"),
			json.Raw.AppendFormat("$.plot({0}", PlaceHolder);

			// data
			json.Raw.Append(",[");
			for (int i = 0, len = Series.Count; i < len; i++)
			{
				if (i > 0)
					json.WriteComma();
				Series[i].ToJson(json);
			}
			json.Raw.Append("]");

			// add options if there are any
			if (FlotChartOptions != null) {
				json.WriteComma();
				FlotChartOptions.ToJson(json);
			}

			json.Raw.Append(");");
		}

		public string ToJson() {
			var json = new JsonBuilder();
			ToJson(json);
			return json.ToString();
		}

		#region Series

		public FlotChart AddSeries(Action<SeriesOptions> builder)
		{
			FlotSeries series = new FlotSeries(this, builder);
			Series.Add(series);
			return this;
		}

		public FlotSeries AddSeries(IEnumerable<FlotPoint> points, Action<SeriesOptions> builder)
		{
			FlotSeries series = new FlotSeries(this, builder);
			series.Add(points);
			Series.Add(series);
			return series;
		}

		public FlotSeries AddSeries<T>(IEnumerable<T> items, Func<T, FlotPoint> func, Action<SeriesOptions> builder)
		{
			FlotSeries series = new FlotSeries(this, builder);
			series.Add(items, func);
			Series.Add(series);
			return series;
		}

		#endregion Series

		#region Options

		public FlotChart Options(Action<FlotChartOptions> chartOptionsBuilder)
		{
			if (FlotChartOptions == null)
				FlotChartOptions = new FlotChartOptions();

			chartOptionsBuilder(FlotChartOptions);

			return this;
		}

		// var options = {
		//   series: {
		//     lines: { show: true },
		//     points: { show: true }
		//   }
		// };



		  //xaxis, yaxis, x2axis, y2axis: {
		  //  mode: null or "time"
		  //  min: null or number
		  //  max: null or number
		  //  autoscaleMargin: null or number
		    
		  //  labelWidth: null or number
		  //  labelHeight: null or number

		  //  transform: null or fn: number -> number
		  //  inverseTransform: null or fn: number -> number
		    
		  //  ticks: null or number or ticks array or (fn: range -> ticks array)
		  //  tickSize: number or array
		  //  minTickSize: number or array
		  //  tickFormatter: (fn: number, object -> string) or string
		  //  tickDecimals: null or number
		  //}

		

		  
		  
		  //colors: [ color1, color2, ... ]

		#endregion

		public static long GetJavascriptTimestamp(System.DateTime input)
		{
			System.TimeSpan span = new System.TimeSpan(System.DateTime.Parse("1/1/1970").Ticks);
			System.DateTime time = input.Subtract(span);
			return (time.Ticks / 10000);
		}
	}

}