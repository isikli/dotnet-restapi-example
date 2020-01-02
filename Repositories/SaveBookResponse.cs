using myrestapi.Models;

namespace myrestapi.Repositories
{
    public class SaveBookResponse
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public Book Book { get; private set; }

        private SaveBookResponse(bool success, string message, Book book)
        {
            Book = book;
            Success = success;
            Message = message;
        }

        public SaveBookResponse(Book book): this(true, "Success", book)
        {
        }

        public SaveBookResponse(string message): this(false, message, null)
        {
		}
	}
}