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
	public class LineOptions {

		public LineOptions() {
			_fields = new Dictionary<Field, object>();
		}

		public LineOptions Show(bool show) {
			return SetValue(Field.Show, show);
		}

		public LineOptions LineWidth(int width) {
			return SetValue(Field.LineWidth, width);
		}

		public LineOptions Fill(bool fill) {
			return SetValue(Field.Fill, fill);
		}

		public LineOptions  FillColor(string color) {
			return SetValue(Field.FillColor, color);
		}

		private object GetField(Field field)
		{
			if (_fields.ContainsKey(field))
				return _fields[field];

			return null;
		}

		internal void ToJson(JsonBuilder json)
		{
			// lines, points, bars: {
			//    show: boolean
			//    lineWidth: number
			//    fill: boolean or number
			//    fillColor: null or color/gradient
			//  }
			json.WriteObject("lines", lines => lines
				.WritePropertyIf("show", GetField(Field.Show), GetField(Field.Show) != null)
				.WritePropertyIf("lineWidth", GetField(Field.LineWidth), GetField(Field.LineWidth) != null)
				.WritePropertyIf("fill", GetField(Field.Fill), GetField(Field.Fill) != null)
				.WritePropertyIf("fillColor", GetField(Field.FillColor), GetField(Field.FillColor) != null)
			);
		}

		public string ToJson()
		{
			var json = new JsonBuilder();
			ToJson(json);
			return json.ToString();
		}

		private enum Field { Show, LineWidth, Fill, FillColor }
		private readonly Dictionary<Field, object> _fields;

		private LineOptions SetValue(Field field, object value)
		{
			_fields[field] = value;
			return this;
		}
	}
}
