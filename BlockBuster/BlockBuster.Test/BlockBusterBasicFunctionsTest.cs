namespace BlockBuster.Test
{
	public class BlockBusterBasicFunctionsTest
	{
		[Fact]
		public static void GetMovieByIdTest()
		{
			var result = BlockBusterBasicFunctions.GetMovieById(11);
			Assert.True(result?.Title == "Vertigo");
			Assert.True(result?.ReleaseYear == 1958);
		}

		[Fact]
		public static void GetAllMoviesTest()
		{
			var result = BlockBusterBasicFunctions.GetAllMovies();
			Assert.True(result.Count == 51);
		}

		[Fact]
		public static void GetAllCheckedOutMoviesTest()
		{
			var result = BlockBusterBasicFunctions.GetAllCheckedOutMovies();
			Assert.True(result.Count == 3);
		}

		/// <summary>
		/// Test retrieving all movies by genre description.
		/// </summary>
		/// <param name="genreId">The genre identifier. In this test, 1 is "Drama".</param>
		/// <returns>True if the count of movies returned is 33; otherwise, false.</returns>
		[Fact]
		public static void GetAllMoviesByGenreDescriptionTest()
		{
			var result = BlockBusterBasicFunctions.GetAllMoviesByGenreDescription(1);
			Assert.True(result.Count == 33);
		}

		/// <summary>
		/// Tests retrieving all movies by the director's last name.
		/// </summary>
		/// <param name="lastName">The last name of the director. In this test, "Curtiz" is used.</param>
		/// <returns>True if the count of movies returned is 3; otherwise, false.</returns>
		[Fact]
		public static void GetAllMoviesByDirectorLastNameTest()
		{
			var result = BlockBusterBasicFunctions.GetAllMoviesByDirectorLastName("Curtiz");
			Assert.True(result.Count == 3);
		}
	}
}