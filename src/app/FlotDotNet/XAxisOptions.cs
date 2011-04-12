
using System.Collections.Generic;

namespace CodeSoda.FluentFlot
{
	public static class AxisMode
	{
		public const string Time = "time";
	}

	public static class TimeFormat
	{
		  //%h: hours
		  //%H: hours (left-padded with a zero)
		  //%M: minutes (left-padded with a zero)
		  //%S: seconds (left-padded with a zero)
		  //%d: day of month (1-31)
		  //%m: month (1-12)
		  //%y: year (four digits)
		  //%b: month name (customizable)
		  //%p: am/pm, additionally switches %h/%H to 12 hour instead of 24
		  //%P: AM/PM (uppercase version of %p)

		public const string MonthNameDay = "%b %d";
	}

	public class XAxisOptions
	{
		private readonly Dictionary<Field, object> _fields;
		private enum Field { Mode, TimeFormat, Min, Max }

		public XAxisOptions()
		{
			_fields = new Dictionary<Field, object>();
		}

		public XAxisOptions Mode(string mode)
		{
			return SetValue(Field.Mode, mode);
		}

		public XAxisOptions TimeFormat(string timeformat)
		{
			return SetValue(Field.TimeFormat, timeformat);
		}

		public XAxisOptions Min(string min)
		{
			return SetValue(Field.Min, min);
		}

		public XAxisOptions Max(string max)
		{
			return SetValue(Field.Max, max);
		}

		internal void ToJson(JsonBuilder json)
		{
			json
				.WriteObject("xaxis", xaxis => xaxis
					.WritePropertyIf("mode", GetValue(Field.Mode), GetValue(Field.Mode) != null)
					.WritePropertyIf("timeformat", GetValue(Field.TimeFormat), GetValue(Field.TimeFormat) != null)
					.WritePropertyIf("min", GetValue(Field.Min), GetValue(Field.Min) != null)
					.WritePropertyIf("max", GetValue(Field.Max), GetValue(Field.Max) != null)
				);
		}

		public string ToJson()
		{
			var json = new JsonBuilder();
			ToJson(json);
			return json.ToString();
		}

		private object GetValue(Field field)
		{
			if (_fields.ContainsKey(field))
				return _fields[field];

			return null;
		}

		private XAxisOptions SetValue(Field field, object value)
		{
			_fields[field] = value;
			return this;
		}
	}
}
