
using System.Collections.Generic;
using System.Text;

namespace CodeSoda.FluentFlot
{

	public class FlotSeries
	{
		
		private readonly List<FlotPoint> _data;
		private SeriesOptions _options;

		public IList<FlotPoint> Data { get { return _data; } }
		public FlotChart Chart { get; private set; }

		public FlotSeries(FlotChart chart):this(chart, null) {}

		public FlotSeries(FlotChart chart, Action<SeriesOptions> builder)
		{
			Chart = chart;
			_data = new List<FlotPoint>();

			if (builder != null) {
				_options = new SeriesOptions();
				builder(_options);
			}
		}

		#region Add

		public FlotSeries Add(int x, int y)
		{
			_data.Add(new FlotPoint(x,y));
			return this;
		}

		public FlotSeries Add(FlotPoint point)
		{
			if (point != null)
				_data.Add(point);
			return this;
		}

		public FlotSeries Add(IEnumerable<FlotPoint> points)
		{
			if (points != null)
				_data.AddRange(points);
			return this;
		}

		public FlotSeries Add<T>(IEnumerable<T> items, Func<T, FlotPoint> func)
		{
			if (items != null) {
				foreach (T item in items)
				{
					this.Add(func(item));
				}
			}

			return this;
		}

		#endregion

		internal void ToJson(JsonBuilder json)
		{

			// decide if the series needs more than just an array
			bool hasPoints = _data.Count > 0;

			if (_options != null)
			{
				json.WriteObject( json2 => {
					_options.ToJson(json2);

					if (hasPoints) {
						json2.WriteProperty("data", _data);
					}
				});
				
			} else
			{

				if (hasPoints)
				{
					json.WriteArray(_data);
				} else
					json.WriteNull();

			}
		}

		public string ToJson()
		{
			var json = new JsonBuilder();
			ToJson(json);
			return json.ToString();
		}

	}
}