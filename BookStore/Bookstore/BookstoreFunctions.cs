using Bookstore.Models;

namespace Bookstore
{
	public class BookstoreFunctions
	{
		public static Book? GetBookByTitle(string title)
		{
			using (var db = new Se407BookStoreContext())
			{
				return db.Books
					.FirstOrDefault(b => b.BookTitle == title);
			}
		}

		public static List<Book> GetAllBooks()
		{
			using (var db = new Se407BookStoreContext())
			{
				return db.Books
					.ToList();
			}
		}

		public static List<Book> GetBooksByAuthorLastName(string lastName)
		{
			using (var db = new Se407BookStoreContext())
			{
				return db.Books
					.Where(b => db.Authors
					.Any(a => a.AuthorId == b.AuthorId && a.AuthorLast == lastName))
					.ToList();
			}
		}
	}
}
