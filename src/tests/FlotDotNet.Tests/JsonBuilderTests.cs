using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeSoda.FluentFlot;
using NUnit.Framework;

namespace FluentFlot.Tests
{
	[TestFixture]
	public class JsonBuilderTests
	{
		[Test]
		public void CanCreate()
		{
			var json = new JsonBuilder();
			Assert.IsNotNull(json);
		}

		[Test]
		public void EmptyBuilder()
		{
			var json = new JsonBuilder().ToString();
			Assert.AreEqual("", json);
		}

		[Test]
		public void MultiplePropertiesTest()
		{
			var json = new JsonBuilder()
				.WriteObject( json2 => json2
					.WriteProperty("property1", 1)
					.WriteProperty("property2", 2)
				)
				.ToString();

			Assert.AreEqual("{property1:1,property2:2}", json);
		}

		[Test]
		public void SimpleNamedObject()
		{
			var json = new JsonBuilder()
				.WriteObject( m => m
					.WriteObject("object1", j => { } )
				)
				.ToString();

			Assert.AreEqual("{object1:{}}", json);
		}

		[Test]
		public void ComplexNamedObject()
		{
			var json = new JsonBuilder()
				.WriteObject( j => j
					.WriteObject("object1", obj1 => obj1
						.WriteProperty("property1", 1)
					)
				)
				.ToString();

			Assert.AreEqual("{object1:{property1:1}}", json);
		}

		[Test]
		public void MultipleNamedObjects()
		{
			var json = new JsonBuilder()
				.WriteObject( root => root
					.WriteObject("object1", obj1 => { })
					.WriteObject("object2", obj2 => { })
				).ToString();

			Assert.AreEqual(
				"{object1:{},object2:{}}",
				json
			);
		}

		[Test]
		public void MultipleNamedComplexObjects()
		{
			var json = new JsonBuilder()
				.WriteObject(root => root
					.WriteObject("object1", obj1 => obj1
						.WriteProperty("prop1", 1)
						.WriteProperty("prop2", 2)
					)
					.WriteObject("object2", obj2 => obj2
						.WriteProperty("prop1", 1)
						.WriteProperty("prop2", 2)
					)
				).ToString();

			Assert.AreEqual(
				"{object1:{prop1:1,prop2:2},object2:{prop1:1,prop2:2}}",
				json
			);
		}

		[Test]
		public void NestedNamedObjects()
		{
			var json = new JsonBuilder()
				.WriteObject(root => root
					.WriteObject("object1", m=>m
						.WriteProperty("property1", 1)
						.WriteObject("object1-1",n=>n
							.WriteProperty("property2",2)
						)
					)
				)
				.ToString();

			Assert.AreEqual(
				"{object1:{property1:1,object1-1:{property2:2}}}",
				json
			);
		}
	}
}
