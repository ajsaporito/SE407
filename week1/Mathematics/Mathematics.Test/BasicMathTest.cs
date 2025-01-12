using Mathematics.Test;

namespace Mathmatics.Test
{
	public class BasicMathTest : IClassFixture<BasicMathTestFixture>
	{
		private BasicMathTestFixture _fixture;

		public BasicMathTest(BasicMathTestFixture fixture)
		{
			_fixture = fixture;
		}

		[Theory]
		[InlineData(5, 3, 8)]
		[InlineData(10, 5, 15)]
		[InlineData(2, 2, 4)]
		[InlineData(10000, 567, 10567)]
		public void TestAddTwoNumbers(double num1, double num2, double expectedResults)
		{
			double result = _fixture.TestObject.AddNumbers(num1, num2);
			Assert.Equal(expectedResults, result);
		}

		[Fact]
		public void TestSubtractTwoNumbers()
		{
			double result = _fixture.TestObject.SubtractNumbers(5, 3);
			Assert.Equal(2, result);
		}

		[Fact]
		public void TestMultiplyTwoNumbers()
		{
			double result = _fixture.TestObject.MultiplyNumbers(5, 3);
			Assert.Equal(15, result);
		}

		[Fact]
		public void TestDivideTwoNumbers()
		{
			double result = _fixture.TestObject.DivideNumbers(6, 3);
			Assert.Equal(2, result);
		}
	}
}
