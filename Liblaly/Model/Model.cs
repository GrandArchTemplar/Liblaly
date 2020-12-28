using System;
using System.Collections.Generic;
using System.Linq;

namespace Liblaly {
    public class Model {
        static Model() {
            CreationTime = new DateTime(2020, 12, 25).Ticks;
        }
        public static long CreationTime { get; set; }
        private readonly DataBase _db;
        

        //allBooks -- all books in 
        private List<Book> AllBooks { get; }
        //allUsers -- all users of library
        public List<User> AllUsers { get; }

        internal void SaveAll() {
            _db.SetUser(AllUsers);
            _db.SetBook(AllBooks);
        }

        //eUsers -- all users with deadline > current_date (outer data)
        //eBooks -- all books with count > 0
        public List<Book> EBooks { get; set; }
        public List<User> EUsers { get; set; }
        public event EventHandler<(int, List<User>)> DestroyUser = delegate { };
        public event EventHandler<(int, List<User>)> ImaginateUser = delegate { };
        public event EventHandler<(int, List<Book>)> MutateBook = delegate { };
        public Model() {
            _db = new DataBase();
            AllBooks = _db.GetBook();
            AllUsers = _db.GetUsers();
            BookInvariant();
            UserInvariant(-1);
            var b = CreationTime;
        }

        //-1 means already exists
        //-2 fail to parse datatime
        internal void AddUser((string un, string ud) e) {
            var u = SeekByNameAllUser(e.un);
            int c = 0;
            if (u != null) {
                c = -1;
            } else {
                var date = ParseDate(e.ud);
                if (date > 0) {
                    AllUsers.Add(new User(e.un, date));
                    UserInvariant(new DateTime(CreationTime).AddDays(3).Ticks);
                } else {
                    c = -2;
                }
                
            }
            ImaginateUser(this, (c, AllUsers));

        }
        //-1 means no user
        internal void DeleteUser(string e) {
            var u = SeekByNameAllUser(e);
            int c = 0;
            if (u == null) {
                c = -1;
            } else {
                AllUsers.RemoveAll(x => x.Name.ToLower() == e.ToLower());
                UserInvariant(new DateTime(CreationTime).AddDays(3).Ticks);
            }
            DestroyUser(this, (c, AllUsers));
        }

        private long ParseDate(string ud) {
            var dates = ud.Split('/');
            try {
                return new DateTime(int.Parse(dates[2]), int.Parse(dates[1]), int.Parse(dates[0])).Ticks;
            } catch (Exception) {
                return -1;
            }
        }

        internal List<User> SeekByNameEUsers(string e) => EUsers.Where(x => x.Name.ToLower().Contains(e.ToLower())).ToList();
        internal List<User> SeekByNameAllUsers(string e) => AllUsers.Where(x => x.Name.ToLower().Contains(e.ToLower())).ToList();
        private void BookInvariant() => EBooks = AllBooks.Where(book => book.Count > 0).ToList();
        private void UserInvariant(long dt) => EUsers = AllUsers.Where(user => user.Deadline > dt).ToList();
        public void MutateBooks(Book book) {
            int c = 0;
            try {
                var b = AllBooks.First(kniga => book.Name.ToLower() == kniga.Name.ToLower());
                b.Count += book.Count;
                if (b.Count < 0) {
                    b.Count -= book.Count;
                    c = -1;
                }
            } catch (InvalidOperationException) {
                if (book.Count < 0) {
                    c = -2;
                } else {
                    AllBooks.Add(book);
                }
            }
            BookInvariant();
            MutateBook(this, (c, EBooks));
        }
        public List<Book> SeekByNameEBook(string s) => EBooks.Where(x => x.Name.ToLower().Contains(s.ToLower())).ToList();

        public User SeekByNameEUser(string s) {
           try {
                return EUsers.First(user => user.Name.ToLower() == s.ToLower());
            } catch (Exception) {
                return null;
            }
        }

        public User SeekByNameAllUser(string s) {
            try {
                return AllUsers.First(user => user.Name.ToLower() == s.ToLower());
            } catch (Exception) {
                return null;
            }
        }

        public (int, List<Book>) ExtractBookFromUser(string userName, string bookName) { 
            var u = EUsers.Find(x => x.Name == userName);
            if (null == u) { 
                return (-1, null);
            }
            var b = u.Books.Find(x => x.Name == bookName);
            if (null == b) {
                return (-1, null);
            }
            u.Books.Remove(b);
            return (0, u.Books);

        }

        public (int, List<Book>) InsertBookToUser(string userName, string bookName) {
            var u = EUsers.Find(x => x.Name == userName);
            if (null == u) { 
                return (-1, null);
            }
            if (u.Books.Find(x => x.Name == bookName) != null) {
                return (-1, null);
            }
            var b = EBooks.Find(x => x.Name == bookName);
            if (null == b) {
                return (-1, null);
            }
            u.Books.Add(new Book(bookName, 1));
            return (0, u.Books);
        }
    }
}

