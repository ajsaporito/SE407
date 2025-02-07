using BlockBuster.Models;

namespace BlockBuster
{
	public class BlockBusterBasicFunctions
	{
		public static Movie? GetMovieById(int id)
		{
			using (var db = new Se407BlockBusterContext())
			{
				return db.Movies.Find(id);
			}
		}

		public static List<Movie> GetAllMovies()
		{
			using (var db = new Se407BlockBusterContext())
			{
				return db.Movies.ToList();
			}
		}

		public static List<Movie> GetAllCheckedOutMovies()
		{
			using (var db = new Se407BlockBusterContext())
			{
				return db.Movies
					.Join(db.Transactions,
					m => m.MovieId,
					t => t.Movie.MovieId,
					(m, t) => new
					{
						MovieId = m.MovieId,
						Title = m.Title,
						ReleaseYear = m.ReleaseYear,
						GenreId = m.GenreId,
						DirectorId = m.DirectorId,
						CheckedIn = t.CheckedIn
					}).Where(w => w.CheckedIn == "N")
					.Select(m => new Movie
					{
						MovieId = m.MovieId,
						Title = m.Title,
						ReleaseYear = m.ReleaseYear,
						GenreId = m.GenreId,
						DirectorId = m.DirectorId
					}).ToList();
			}
		}

		public static List<Movie> GetAllMoviesByGenreDescription(int genreId)
		{
			using (var db = new Se407BlockBusterContext())
			{
				return db.Movies.Where(m => m.GenreId == genreId).ToList();
			}
		}

		public static List<Movie> GetAllMoviesByDirectorLastName(string lastName)
		{
			using (var db = new Se407BlockBusterContext())
			{
				return db.Movies
					.Where(m => db.Directors
					.Any(d => d.DirectorId == m.DirectorId && d.LastName == lastName))
					.ToList();
			}
		}
	}
}
