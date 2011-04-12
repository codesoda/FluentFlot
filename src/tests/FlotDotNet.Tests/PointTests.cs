using System;
using System.Collections.Generic;
using System.Text;
using CodeSoda.FluentFlot;
using NUnit.Framework;

namespace FluentFlot.Tests
{
	[TestFixture]
	public class PointTests
	{
		[Test]
		public void CanCreatePoint() {
			var point = new FlotPoint(1,2);
			Assert.AreEqual(1, point.X);
			Assert.AreEqual(2, point.Y);
		}

		[Test]
		public void PointToJson()
		{
			var point = new FlotPoint(1, 2);
			string json = point.ToString();

			Assert.AreEqual("[1,2]", json);
		}
	}
}
