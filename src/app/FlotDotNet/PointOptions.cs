using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSoda.FluentFlot
{

	// lines, points, bars: {
	//    show: boolean
	//    lineWidth: number
	//    fill: boolean or number
	//    fillColor: null or color/gradient
	//  }
	public class PointOptions {

		private enum Field { Show, LineWidth, Fill, FillColor, Radius }
		private readonly Dictionary<Field, object> _fields;

		public PointOptions()
		{
			_fields = new Dictionary<Field, object>();
			foreach (Field field in Enum.GetValues(typeof(Field)))
				_fields[field] = null;
		}

		public PointOptions Show(bool show)
		{
			return SetValue(Field.Show, show);
		}

		public PointOptions LineWidth(int width)
		{
			return SetValue(Field.LineWidth, width);
		}

		public PointOptions Fill(bool fill)
		{
			return SetValue(Field.Fill, fill);
		}

		public PointOptions FillColor(string color)
		{
			return SetValue(Field.FillColor, color);
		}

		public PointOptions Radius(int radius) {
			return SetValue(Field.Radius, radius);
		}

		internal void ToJson(JsonBuilder json)
		{
			// lines, points, bars: {
			//    show: boolean
			//    lineWidth: number
			//    fill: boolean or number
			//    fillColor: null or color/gradient
			//  }
			json.WriteObject("points", points => points
				.WritePropertyIf("show", _fields[Field.Show], _fields[Field.Show] != null)
				.WritePropertyIf("lineWidth", _fields[Field.LineWidth], _fields[Field.LineWidth] != null)
				.WritePropertyIf("fill", _fields[Field.Fill], _fields[Field.Fill] != null)
				.WritePropertyIf("fillColor", _fields[Field.FillColor], _fields[Field.FillColor] != null)
				.WritePropertyIf("radius", _fields[Field.Radius], _fields[Field.Radius] != null)
			);
		}

		public string ToJson()
		{
			var json = new JsonBuilder();
			ToJson(json);
			return json.ToString();
		}

		private PointOptions SetValue(Field field, object value)
		{
			_fields[field] = value;
			return this;
		}
	}
}
