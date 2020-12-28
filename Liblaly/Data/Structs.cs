using System.Collections.Generic;

namespace Liblaly.Data {
    public struct BookStruct {
        public Book Book { get; }
        public BookStruct(Book book) => Book = book;
    }
    public struct UserStruct {
        public User User { get; }
        public UserStruct(User user) => User = user;
    }
    public struct ListBookStruct {
        public List<Book> Books { get; }
        public ListBookStruct(List<Book> books) => Books = books;
    }
}
