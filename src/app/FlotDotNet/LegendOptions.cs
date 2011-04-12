
using System.Collections.Generic;

namespace CodeSoda.FluentFlot
{
	//legend: {
	//  show: boolean
	//  labelFormatter: null or (fn: string, series object -> string)
	//  labelBoxBorderColor: color
	//  noColumns: number
	//  position: "ne" or "nw" or "se" or "sw"
	//  margin: number of pixels or [x margin, y margin]
	//  backgroundColor: null or color
	//  backgroundOpacity: number between 0 and 1
	//  container: null or jQuery object/DOM element/jQuery expression
	//}

	public enum LegendPosition
	{
		NE,
		NW,
		SE,
		SW
	}

	public class LegendOptions
	{
		private enum Field { Show, Position, LabelFormatter, LabelBoxBorderColor, NoColumns, Margin, BackgroundColor, BackgroundOpacity, Container }
		private readonly Dictionary<Field, object> _fields;

		private LegendOptions SetValue(Field field, object value) {
			_fields[field] = value;
			return this;
		}

		public LegendOptions()
		{
			_fields = new Dictionary<Field, object>();
		}

		public LegendOptions Show(bool show)
		{
			return SetValue(Field.Show, show);
		}
		
		public LegendOptions Position(LegendPosition position)
		{
			return SetValue(Field.Position, position.ToString().ToLower());
		}

		internal void ToJson(JsonBuilder json)
		{
			//legend: {
			//  show: boolean
			//  labelFormatter: null or (fn: string, series object -> string)
			//  labelBoxBorderColor: color
			//  noColumns: number
			//  position: "ne" or "nw" or "se" or "sw"
			//  margin: number of pixels or [x margin, y margin]
			//  backgroundColor: null or color
			//  backgroundOpacity: number between 0 and 1
			//  container: null or jQuery object/DOM element/jQuery expression
			//}

			json.WriteObject("legend", legend => legend
				.WritePropertyIf("show", GetValue(Field.Show), GetValue(Field.Show) != null)
				.WritePropertyIf("position",GetValue(Field.Position), GetValue(Field.Position) != null )
			);
		}

		public string ToJson()
		{
			var json = new JsonBuilder();
			ToJson(json);
			return json.ToString();
		}

		private object GetValue(Field field, Func<object, object> formatter)
		{
			var obj = GetValue(field);
			return formatter(obj);
		}

		private object GetValue(Field field) {
			if (_fields.ContainsKey(field))
				return _fields[field];

			return null;
		}

	}
}
