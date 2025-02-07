using BlockBuster.Models;
using CsvHelper;
using System.Globalization;

namespace BlockBuster.ConsoleApp
{
	public class ConsoleUtils
	{
		public static void WriteToConsole(IEnumerable<Movie> movies)
		{
			Console.WriteLine($"{"MovieID",-10} {"Movie Title",-50} {"Release Year",-15}");
			Console.WriteLine(new string('-', 74));

			foreach (Movie movie in movies)
			{
				Console.WriteLine($"{movie.MovieId,-10} {movie.Title,-50} {movie.ReleaseYear,-15}");
			}
		}

		public static void WriteToCsv(IEnumerable<Movie> movies)
		{
			using (var streamWriter = new StreamWriter("..\\Movies.csv"))
			{
				using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
				{

					csvWriter.WriteRecords(movies);
				}
			}
		}
	}
}
