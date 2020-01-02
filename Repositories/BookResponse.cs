using myrestapi.Models;

namespace myrestapi.Repositories
{
    public class BookResponse
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public Book Book { get; private set; }

        private BookResponse(bool success, string message, Book book)
        {
            Book = book;
            Success = success;
            Message = message;
        }

        public BookResponse(Book book): this(true, "Success", book)
        {
        }

        public BookResponse(string message): this(false, message, null)
        {
		}
	}
}