using Bookstore.Models;
using CsvHelper;
using System.Globalization;

namespace Bookstore.ConsoleApp
{
	public class ConsoleUtils
	{
		public static void WriteToConsole(IEnumerable<Book> books)
		{
			Console.WriteLine($"{"BookID",-10} {"Book Title",-28} {"Year of Release",-15}");
			Console.WriteLine(new string('-', 55));

			foreach (Book book in books)
			{
				Console.WriteLine($"{book.BookId,-10} {book.BookTitle,-28} {book.YearOfRelease,-15}");
			}
		}

		public static void WriteToCsv(IEnumerable<Book> books)
		{
			using (var streamWriter = new StreamWriter("..\\Books.csv"))
			{
				using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
				{

					csvWriter.WriteRecords(books);
				}
			}
		}
	}
}
