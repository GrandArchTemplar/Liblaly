using System;
using System.Collections.Generic;
using System.Windows;

namespace Liblaly.View {
    /// <summary>
    /// Interaction logic for BookManagement.xaml
    /// </summary>
    public partial class BookManageView : Window {
        public BookManageView() {
            InitializeComponent();
        }
        public event EventHandler<BookArgs> MutateBook = delegate { };
        public void SynthesisUniverseBooks(List<Book> books) {
            BookList.ItemsSource = books;
            BookList.Items.Refresh();
            
        }
        private void SynthesisError(string err) => new Error(err) { Owner = this }.Show();
        public void RegenerateBooks(List<Book> books, int e) {
            if (e != 0) {
                SynthesisError(e == -2 ? "попытка создать отрицательное число книг" : "отобрали слишком много книг");
            } else {
                SynthesisUniverseBooks(books);
            }
        }

        private void MutateBookClick(object sender, RoutedEventArgs e) {
            try {
                var count = int.Parse(synth_count.Text);
                MutateBook(this, new BookArgs(new Book(synth_name.Text, count)));
            } catch (Exception) {
                SynthesisError("не получилось считать количество книг для мутирования");
            }
        }
    }
}
