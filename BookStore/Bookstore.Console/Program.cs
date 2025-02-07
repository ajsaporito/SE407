using Bookstore.Models;

namespace Bookstore.ConsoleApp
{
	public class Program
	{
		static void Main()
		{
			string[] args = Environment.GetCommandLineArgs();

			if (args.Length < 3)
			{
				Error();
			}

			string outputType = args[1].ToLower();
			string command = args[2].ToLower();
			string parameter = args.Length > 3 ? args[3] : string.Empty;

			IEnumerable<Book> books = ExecuteCommand(command, parameter);

			if (outputType == "console")
			{
				ConsoleUtils.WriteToConsole(books);
			}
			else if (outputType == "csv")
			{
				ConsoleUtils.WriteToCsv(books);
				Console.WriteLine("Movies written to CSV successfully.");
			}
			else
			{
				Error();
			}

			Console.ReadLine();
		}

		private static IEnumerable<Book> ExecuteCommand(string command, string parameter)
		{
			switch (command)
			{
				case "getbookbytitle":
					if (!string.IsNullOrEmpty(parameter))
					{
						var book = BookstoreFunctions.GetBookByTitle(parameter);
						return book == null ? new List<Book>() : new List<Book> { book };
					}
					else
					{
						Console.WriteLine("This command requires a parameter (string: Book Title).");
						Environment.Exit(99);
					}
					break;

				case "getallbooks":
					return BookstoreFunctions.GetAllBooks();

				case "getbooksbyauthorlastname":
					if (!string.IsNullOrEmpty(parameter))
					{
						return BookstoreFunctions.GetBooksByAuthorLastName(parameter);
					}
					else
					{
						Console.WriteLine("This command requires a parameter (string: Author Last Name).");
						Environment.Exit(99);
					}
					break;

				default:
					Error();
					break;
			}

			return new List<Book>();
		}

		public static void Error()
		{
			Console.WriteLine("Argument Error:");
			Console.WriteLine("\nUsage: <output-type> <command> [parameter].");
			Console.WriteLine("\nAvailable output types: \nconsole \ncsv");
			Console.WriteLine("\nAvailable commands: \ngetbookbytitle \ngetallbooks \ngetbooksbyauthorlastname");
			Environment.Exit(99);
		}
	}
}
