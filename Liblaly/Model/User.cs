using System;
using System.Collections.Generic;

namespace Liblaly {
    public class User {
        public string Name { get; }
        public long Deadline { get; set; }
        public List<Book> Books { get; }
        public User(string name, long creationTime) {
            Name = name;
            Books = new List<Book>();
            Deadline = creationTime;

        }
    }
}
