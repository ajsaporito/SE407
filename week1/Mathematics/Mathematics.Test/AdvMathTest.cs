using Mathematics.Test;

namespace Mathmatics.Test
{
	public class AdvMathTest : IClassFixture<AdvMathTestFixture>
	{
		private AdvMathTestFixture _fixture;

		public AdvMathTest(AdvMathTestFixture fixture)
		{
			_fixture = fixture;
		}

		[Theory]
		[InlineData(2, 3, 6)]
		[InlineData(12, 5, 60)]
		[InlineData(3, 3, 9)]
		[InlineData(14, 6, 84)]
		public void TestCalculateArea(double num1, double num2, double expectedResults)
		{
			double result = _fixture.TestObject.CalculateArea(num1, num2);
			Assert.Equal(expectedResults, result);
		}

		[Fact]
		public void TestCalculateAverage()
		{
			List<double> numbers = [10, 11, 12, 13, 14, 10, 13, 13];
			double result = _fixture.TestObject.CalculateAverage(numbers);
			Assert.Equal(12, result);
		}

		[Fact]
		public void TestCalculateSquareNumber()
		{
			double result = _fixture.TestObject.CalculateSquareNumber(5);
			Assert.Equal(25, result);
		}

		[Fact]
		public void TestCalculatePythagoreanTheorem()
		{
			double result = _fixture.TestObject.CalculatePythagoreanTheorem(6, 8);
			Assert.Equal(10, result);
		}
	}
}
