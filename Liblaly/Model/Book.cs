namespace Liblaly {
    public class Book {
        public string Name { get; }
 
        public int Count { get; set; }
        public Book(string name, int count) {
            Name = name;
            Count = count;
        }
    }
   
}

