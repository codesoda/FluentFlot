using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CodeSoda.FluentFlot
{
	public class JsonBuilder
	{
		private readonly StringBuilder _sb;
		private readonly Stack<bool> _hasPreviousProperties;

		private bool RequiresComma { get { return _hasPreviousProperties.Count > 0 && _hasPreviousProperties.Peek(); } }


		public JsonBuilder() {
			_sb = new StringBuilder();
			_hasPreviousProperties = new Stack<bool>();
		}


		public JsonBuilder WriteObject(string name, Action<JsonBuilder> buildChildren)
		{
			WriteCommaIf(RequiresComma);

			if (_hasPreviousProperties.Count > 0) {
				_hasPreviousProperties.Pop();
			}
			_hasPreviousProperties.Push(false);

			_sb.AppendFormat("{0}:{{", name);
			buildChildren(this);
			_sb.Append("}");

			if (_hasPreviousProperties.Count > 0) {
				_hasPreviousProperties.Pop();
			}
			_hasPreviousProperties.Push(true);

			return this;
		}


		public JsonBuilder WriteObject( Action<JsonBuilder> buildChildren )
		{
			// if object is anonymous don't write comma, the coder should have done it
			_sb.Append("{");

			if (_hasPreviousProperties.Count > 0) {
				_hasPreviousProperties.Pop();
			}
			_hasPreviousProperties.Push(false);

			buildChildren(this);
			_sb.Append("}");
			
			return this;
		}


		public JsonBuilder WritePropertyIf(string name, object value, bool onlyIf) {
			if (onlyIf)
				return WriteProperty(name, value);

			return this;
		}


		public JsonBuilder WriteProperty(string name, object value)
		{
			WriteCommaIf(RequiresComma);

			_sb.AppendFormat("{0}:", name);

			WriteObject(value);

			if (_hasPreviousProperties.Count > 0)
				_hasPreviousProperties.Pop();

			_hasPreviousProperties.Push(true);

			return this;
		}


		public void WriteNull()
		{
			_sb.Append("null");
		}


		public void WriteArray(IEnumerable values)
		{
			_sb.Append("[");
			_hasPreviousProperties.Push(false);

			foreach (object value in values)
			{
				WriteCommaIf(RequiresComma);
				WriteObject(value);

				_hasPreviousProperties.Pop();
				_hasPreviousProperties.Push(true);
			}

			_sb.Append("]");
		}


		public StringBuilder Raw { get { return _sb; } }

		public override string ToString()
		{
			return _sb.ToString();
		}

		private void WriteCommaIf(bool ifOnly)
		{
			if (ifOnly)
				WriteComma();
		}

		public void WriteComma() {
			_sb.Append(",");
		}

		private void WriteObject(object value)
		{
			if (value == null)
				WriteNull();
			else if (value is string)
				WriteString((string)value);
			else if (value is bool)
				WriteBoolean((bool)value);
			else if (value is int)
				WriteInt32((int)value);
			else if (value is double)
				WriteDouble((double)value);
			else if (value is IEnumerable)
				WriteArray((IEnumerable)value);
			else
				_sb.Append(value.ToString()); // ewww
		}

		private void WriteBoolean(bool value) {
			_sb.Append(value.ToString().ToLower());
		}

		private void WriteString(string value) {
			_sb.AppendFormat("\"{0}\"", value.Replace(@"\", "" ).Replace("\"", "\\\""));
		}

		private void WriteInt32(int value) {
			_sb.Append(value);
		}

		private void WriteDouble(double value) {
			_sb.Append(value);
		}

	}
}
