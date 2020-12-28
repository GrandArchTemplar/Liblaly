using Liblaly.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Liblaly {
    class DataBase {
        public List<Book> GetBook() =>
            new List<string>(System.IO.File.ReadAllLines("books.txt"))
                .Select(x => new BookParser()
                    .Parse((x, (BookStruct?)new BookStruct(new Book("", 0)))).Item2?.Book)
                .ToList();

        public List<User> GetUsers() {
            return new List<string>(System.IO.File.ReadAllLines("users.txt"))
                .Select(x => new UserParser()
                    .Parse((x, new UserStruct(new User("", 0)))).Item2?.User)
                .ToList();
        }

        public void SetBook(List<Book> books) {
            System.IO.File.WriteAllLines("books.txt", books.Select(book => book.Name + ";" + book.Count));
        }
        public void SetUser(List<User> users) {
            System.IO.File.WriteAllLines(
                "users.txt", 
                users.Select(user => 
                user.Name + ";" + 
                user.Deadline + ";" + 
                String.Join(";",user.Books.Select(x => x.Name))));
        }
    }
}

