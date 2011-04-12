
namespace CodeSoda.FluentFlot
{
	public class FlotPoint
	{

		public long X { get; private set; }
		public long Y { get; private set; }

		public FlotPoint(long x, long y)
		{
			this.X = x;
			this.Y = y;
		}

		public override string ToString()
		{
			return string.Format("[{0},{1}]", X, Y);
		}

	}
}
