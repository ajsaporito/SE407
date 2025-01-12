namespace Mathematics
{
	public class AdvMath
	{
		public double CalculateArea(double height, double width)
		{
			return height * width;
		}

		public double CalculateAverage(List<double> numbers)
		{
			double total = 0;

			foreach (double num in numbers)
			{
				total += num;
			}
			return total / numbers.Count;
		}

		public double CalculateSquareNumber(double num)
		{
			return Math.Pow(num, 2);
		}

		public double CalculatePythagoreanTheorem(double a, double b)
		{
			return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
		}
	}
}
