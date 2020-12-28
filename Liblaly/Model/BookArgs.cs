using System;

namespace Liblaly {
    public class BookArgs : EventArgs { 
        public Book Book { get; } 
        public BookArgs(Book book) => Book = book; 
    }
}
