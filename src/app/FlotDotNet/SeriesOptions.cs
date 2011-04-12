using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSoda.FluentFlot
{

	//series: {
	//  lines, points, bars: {
	//    show: boolean
	//    lineWidth: number
	//    fill: boolean or number
	//    fillColor: null or color/gradient
	//  }

	//  points: {
	//    radius: number
	//  }

	//  bars: {
	//    barWidth: number
	//    align: "left" or "center"
	//    horizontal: boolean
	//  }

	//  lines: {
	//    steps: boolean
	//  }

	//  shadowSize: number
	//}

	public class SeriesOptions
	{

		#region Lines, Points, Bars

		private LineOptions _lineOptions;
		private PointOptions _pointOptions;
		private BarOptions _barOptions;

		public SeriesOptions Lines(Action<LineOptions> lineOptionsBuilder)
		{
			if (_lineOptions == null)
				_lineOptions = new LineOptions();

			lineOptionsBuilder(_lineOptions);

			return this;
		}

		public SeriesOptions Points(Action<PointOptions> pointOptionsBuilder)
		{
			if (_pointOptions == null)
				_pointOptions = new PointOptions();

			pointOptionsBuilder(_pointOptions);

			return this;
		}

		public SeriesOptions Bars(Action<BarOptions> barOptionsBuilder)
		{
			if (_barOptions == null)
				_barOptions = new BarOptions();

			barOptionsBuilder(_barOptions);

			return this;
		}

		#endregion

		private readonly Dictionary<Field, object> _fields;
		private enum Field { Color, Label, XAxis, YAxis, Clickable, Hoverable, ShadowSize }

		public SeriesOptions Color(string color)
		{
			return SetValue(Field.Color, color);
		}

		public SeriesOptions Label(string label)
		{
			return SetValue(Field.Label, label);
		}

		public SeriesOptions XAxis(int xaxis)
		{
			return SetValue(Field.XAxis, xaxis);
		}

		public SeriesOptions YAxis(int yaxis)
		{
			return SetValue(Field.YAxis, yaxis);
		}

		public SeriesOptions Clickable(bool clickable)
		{
			return SetValue(Field.Clickable, clickable);
		}

		public SeriesOptions Hoverable(bool hoverable)
		{
			return SetValue(Field.Hoverable, hoverable);
		}

		public SeriesOptions ShadowSize(int shadowSize)
		{
			return SetValue(Field.ShadowSize, shadowSize);
		}

		public SeriesOptions() {
			_fields = new Dictionary<Field, object>();
		}

		internal void ToJson(JsonBuilder json)
		{
			json
				//.BeginObject()
					.WritePropertyIf(
						"color",
						_fields.ContainsKey(Field.Color)
							? _fields[Field.Color]
							: null,
						_fields.ContainsKey(Field.Color)
					)
					.WritePropertyIf(
						"label",
						_fields.ContainsKey(Field.Label)
							? _fields[Field.Label]
							: null,
						_fields.ContainsKey(Field.Label)
					)
					.WritePropertyIf(
						"xaxis",
						_fields.ContainsKey(Field.XAxis)
							? _fields[Field.XAxis]
							: null,
						_fields.ContainsKey(Field.XAxis)
					)
					.WritePropertyIf(
						"yaxis",
						_fields.ContainsKey(Field.YAxis)
							? _fields[Field.YAxis]
							: null,
						_fields.ContainsKey(Field.YAxis)
					)
					.WritePropertyIf(
						"clickable",
						_fields.ContainsKey(Field.Clickable)
							? _fields[Field.Clickable]
							: null,
						_fields.ContainsKey(Field.Clickable)
					)
					.WritePropertyIf(
						"hoverable",
						_fields.ContainsKey(Field.Hoverable)
							? _fields[Field.Hoverable]
							: null,
						_fields.ContainsKey(Field.Hoverable)
					)
					.WritePropertyIf(
						"shadowSize",
						_fields.ContainsKey(Field.ShadowSize)
							? _fields[Field.ShadowSize]
							: null,
						_fields.ContainsKey(Field.ShadowSize)
					);

			if (_lineOptions != null)
				_lineOptions.ToJson(json);

			if (_barOptions != null)
				_barOptions.ToJson(json);

			if (_pointOptions != null)
				_pointOptions.ToJson(json);
		}

		public string ToJson()
		{
			var json = new JsonBuilder();
			ToJson(json);
			return json.ToString();
		}

		private SeriesOptions SetValue(Field field, object value)
		{
			_fields[field] = value;
			return this;
		}
	}
}
