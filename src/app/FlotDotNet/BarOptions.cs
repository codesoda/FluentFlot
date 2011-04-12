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
	public class BarOptions {

		private enum Field { Show, LineWidth, Fill, FillColor }
		private readonly Dictionary<Field, object> _fields;

		public BarOptions()
		{
			_fields = new Dictionary<Field, object>();
			foreach (Field field in Enum.GetValues(typeof(Field)))
				_fields[field] = null;
		}

		public BarOptions Show(bool show)
		{
			return SetValue(Field.Show, show);
		}

		public BarOptions LineWidth(int width)
		{
			return SetValue(Field.LineWidth, width);
		}

		public BarOptions Fill(bool fill)
		{
			return SetValue(Field.Fill, fill);
		}

		public BarOptions FillColor(string color)
		{
			return SetValue(Field.FillColor, color);
		}

		internal void ToJson(JsonBuilder json)
		{
			// lines, points, bars: {
			//    show: boolean
			//    lineWidth: number
			//    fill: boolean or number
			//    fillColor: null or color/gradient
			//  }
			json.WriteObject("bars", bars=>bars
				.WritePropertyIf("show", _fields[Field.Show], _fields[Field.Show] != null)
				.WritePropertyIf("lineWidth", _fields[Field.LineWidth], _fields[Field.LineWidth] != null)
				.WritePropertyIf("fill", _fields[Field.Fill], _fields[Field.Fill] != null)
				.WritePropertyIf("fillColor", _fields[Field.FillColor], _fields[Field.FillColor] != null)
			);
		}

		public string ToJson()
		{
			var json = new JsonBuilder();
			ToJson(json);
			return json.ToString();
		}

		private BarOptions SetValue(Field field, object value)
		{
			_fields[field] = value;
			return this;
		}
	}
}
