using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeSoda.FluentFlot;
using NUnit.Framework;

namespace FluentFlot.Tests
{
	[TestFixture]
	public class LineOptionTests
	{

		[Test]
		public void CanCreateLineOptions()
		{
			new LineOptions();
		}

		[Test]
		public void BasicJson()
		{
			var json = new LineOptions().ToJson();
		}

		[Test]
		public void Test3()
		{
			var json = new LineOptions()
				.Show(true)
				.Fill(true)
				.FillColor("#222")
				.LineWidth(2)
				.ToJson();
		}


	}
}
