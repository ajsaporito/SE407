namespace Mathematics.Test
{
	public class BasicMathTestFixture : IDisposable
	{
		private BasicMath _testObject;

		public BasicMath TestObject { get => _testObject; }

		public BasicMathTestFixture()
		{
			_testObject = new BasicMath();
		}

		public void Dispose() { }
	}
}
