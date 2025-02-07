namespace Bookstore.Test
{
	public class BookstoreTest
	{
		[Fact]
		public void GetBookByTitleTest()
		{
			var result = BookstoreFunctions.GetBookByTitle("Canterbury Tales");
			Assert.True(result?.BookTitle == "Canterbury Tales");
			Assert.True(result?.BookId == 2);
		}

		[Fact]
		public void GetAllBooksTest()
		{
			var result = BookstoreFunctions.GetAllBooks();
			Assert.True(result.Count == 3);
		}

		[Fact]
		public void GetBooksByAuthorLastNameTest()
		{
			var result = BookstoreFunctions.GetBooksByAuthorLastName("Chaucer");
			Assert.True(result.Count == 2);
		}
	}
}
