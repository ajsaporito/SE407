using Mathematics;

namespace Mathematics.ConsoleApp
{
	class Program
	{
		private static List<double>? _numbers;
		private static string? _operand;

		static void Main()
		{
			string[] args = Environment.GetCommandLineArgs();

			ValidArgumentDataType(args);

			var basicMath = new BasicMath();
			var advMath = new AdvMath();

			switch (_operand)
			{
				case "add":
					if (_numbers != null && ValidArgumentCount(_numbers.Count, 2))
					{
						Console.WriteLine($"Add: The result is {basicMath.AddNumbers(_numbers[0], _numbers[1])}.");
					}
					break;

				case "subtract":
					if (_numbers != null && ValidArgumentCount(_numbers.Count, 2))
					{
						Console.WriteLine($"Subtract: The result is {basicMath.SubtractNumbers(_numbers[0], _numbers[1])}.");
					}
					break;

				case "multiply":
					if (_numbers != null && ValidArgumentCount(_numbers.Count, 2))
					{
						Console.WriteLine($"Multiply: The result is {basicMath.MultiplyNumbers(_numbers[0], _numbers[1])}.");
					}
					break;

				case "divide":
					if (_numbers != null && ValidArgumentCount(_numbers.Count, 2))
					{
						Console.WriteLine($"Divide: The result is {basicMath.DivideNumbers(_numbers[0], _numbers[1])}.");
					}
					break;

				case "area":
					if (_numbers != null && ValidArgumentCount(_numbers.Count, 2))
						Console.WriteLine($"Area: The result is {advMath.CalculateArea(_numbers[0], _numbers[1])}.");
					break;

				case "average":
					if (_numbers != null && _numbers.Count > 0)
					{
						Console.WriteLine($"Average: The result is {advMath.CalculateAverage(_numbers)}.");
					}
					else
					{
						Console.WriteLine("Not enough arguments.");
						Environment.Exit(99);
					}
					break;

				case "square":
					if (_numbers != null && ValidArgumentCount(_numbers.Count, 1))
					{
						Console.WriteLine($"Square: {advMath.CalculateSquareNumber(_numbers[0])}.");
					}
					break;

				case "pythagorean":
					if (_numbers != null && ValidArgumentCount(_numbers.Count, 2))
					{
						Console.WriteLine($"Pythagorean: {advMath.CalculatePythagoreanTheorem(_numbers[0], _numbers[1])}.");
					}
					break;

				default:
					Console.WriteLine($"{_operand} is not a valid operator. Please enter 'add', 'subtract', 'multiply', or 'divide', 'area', 'average, 'square', or 'pythagorean'.");
					break;
			}

			Console.ReadLine();
		}

		public static void ValidArgumentDataType(string[] args)
		{
			_operand = args[1].ToLower();
			_numbers = new List<double>();

			for (var i = 2; i < args.Length; i++)
			{
				double number = NumParser(args[i]);
				_numbers.Add(number);
			}

			Console.WriteLine($"Operand: {_operand}");
			Console.WriteLine($"Arguments: {string.Join(", ", _numbers)}");
		}

		public static double NumParser(string arg)
		{
			if (double.TryParse(arg, out double number))
			{
				return number;
			}
			else
			{
				Console.WriteLine($"Unable to parse {arg}.");
				Environment.Exit(99);
			}

			return 0;
		}

		private static bool ValidArgumentCount(int argCount, int argsRequired)
		{
			if (argCount > argsRequired)
			{
				Console.WriteLine("Too many arguments");
				Environment.Exit(99);
				return false;
			}
			else if (argCount < argsRequired)
			{
				Console.WriteLine("Not enough arguments.");
				Environment.Exit(99);
				return false;
			}

			return true;
		}
	}
}
