using BlockBuster.Models;

namespace BlockBuster.ConsoleApp
{
	public class Program
	{
		static void Main()
		{
			string[] args = Environment.GetCommandLineArgs();

			if (args.Length < 3)
			{
				Error();
				Environment.Exit(99);
			}

			string outputType = args[1].ToLower();
			string command = args[2].ToLower();
			string parameter = args.Length > 3 ? args[3] : string.Empty;

			IEnumerable<Movie> movies = ExecuteCommand(command, parameter);

			if (outputType == "console")
			{
				ConsoleUtils.WriteToConsole(movies);
			}
			else if (outputType == "csv")
			{
				ConsoleUtils.WriteToCsv(movies);
				Console.WriteLine("Movies written to CSV successfully.");
			}
			else
			{
				Error();
			}

			Console.ReadLine();
		}

		private static IEnumerable<Movie> ExecuteCommand(string command, string parameter)
		{
			switch (command)
			{
				case "getmoviebyid":
					if (int.TryParse(parameter, out int movieId))
					{
						var movie = BlockBusterBasicFunctions.GetMovieById(movieId);
						return movie != null ? new List<Movie> { movie } : new List<Movie>();
					}
					else
					{
						Console.Write("This command requires a parameter (int: Movie ID).");
						Environment.Exit(99);
					}
					break;

				case "getallmovies":
					return BlockBusterBasicFunctions.GetAllMovies();

				case "getallcheckedoutmovies":
					return BlockBusterBasicFunctions.GetAllCheckedOutMovies();

				case "getallmoviesbygenredescription":
					if (int.TryParse(parameter, out int genreId))
					{
						return BlockBusterBasicFunctions.GetAllMoviesByGenreDescription(genreId);
					}
					else
					{
						Console.Write("This command requires a parameter (int: Genre ID).");
						Environment.Exit(99);
					}
					break;

				case "getallmoviesbydirectorlastname":
					if (!string.IsNullOrEmpty(parameter))
					{
						return BlockBusterBasicFunctions.GetAllMoviesByDirectorLastName(parameter);
					}
					else
					{
						Console.Write("This command requires a parameter (string: Director Last Name).");
						Environment.Exit(99);
					}
					break;

				default:
					Error();
					Environment.Exit(99);
					break;
			}

			return new List<Movie>();
		}

		public static void Error()
		{
			Console.WriteLine("Argument Error:");
			Console.WriteLine("\nUsage: <output-type> <command> [parameters].");
			Console.WriteLine("\nAvailable output types: \nconsole \ncsv");
			Console.WriteLine("\nAvailable commands: \ngetmoviebyid \ngetallmovies \ngetallcheckedoutmovies \ngetallmoviesbygenredescription \ngetallmoviesbydirectorlastname");
		}
	}
}
