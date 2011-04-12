
namespace CodeSoda.FluentFlot
{
	public class FlotChartOptions {

		private LineOptions _lineOptions;
		private LineOptions _pointOptions;
		private LineOptions _barOptions;
		private XAxisOptions _xaxisOptions;
		private LegendOptions _legendOptions;

		public FlotChartOptions Legend(Action<LegendOptions> legendBuilder)
		{
			if (_legendOptions == null)
				_legendOptions = new LegendOptions();

			legendBuilder(_legendOptions);

			return this;
		}
		
		public FlotChartOptions XAxis(Action<XAxisOptions> xaxisBuilder)
		{
			if (_xaxisOptions == null)
				_xaxisOptions = new XAxisOptions();

			xaxisBuilder(_xaxisOptions);

			return this;
		}

		public FlotChartOptions Lines(Action<LineOptions> lineOptionsBuilder)
		{
			if (_lineOptions == null)
				_lineOptions = new LineOptions();

			lineOptionsBuilder(_lineOptions);

			return this;
		}

		public FlotChartOptions Points(Action<LineOptions> pointOptionsBuilder)
		{
			if (_pointOptions == null)
				_pointOptions = new LineOptions();

			pointOptionsBuilder(_pointOptions);

			return this;
		}

		public FlotChartOptions Bars(Action<LineOptions> barOptionsBuilder)
		{
			if (_barOptions == null)
				_barOptions = new LineOptions();

			barOptionsBuilder(_barOptions);

			return this;
		}

		public void ToJson(JsonBuilder json)
		{
			json.WriteObject( json2 => {

				if (_lineOptions != null)
					_lineOptions.ToJson(json);

				if (_barOptions != null)
					_barOptions.ToJson(json);

				if (_pointOptions != null)
					_pointOptions.ToJson(json);

				if (_xaxisOptions != null)
					_xaxisOptions.ToJson(json);

				if (_legendOptions != null)
					_legendOptions.ToJson(json);
			});

		}

		public string ToJson()
		{
			var json = new JsonBuilder();
			ToJson(json);
			return json.ToString();
		}
	}
}
