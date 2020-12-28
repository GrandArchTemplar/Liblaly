using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Liblaly.View {
    /// <summary>
    /// Interaction logic for UserManageView.xaml
    /// </summary>
    public partial class UserBookManageView : Window {
        public event EventHandler<string> TheChosenOneUser = delegate { };
        public event EventHandler<string> BookSeeker = delegate { };
        public event EventHandler<string> UserSeeker = delegate { };

        //true means return, false means extract
        //first string is book name
        //second string is user name
        public event EventHandler<(bool, string, string)> TransferBook = delegate { };
        public UserBookManageView() {
            InitializeComponent();
        }
        public void SynthesisUniversalUser(List<User> users) {
            Users.ItemsSource = users.Select(user => user.Name);
        }
        public void SynthesisError(string err) => new Error(err) { Owner = this }.Show();

        private void TheChosenOne_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            TheChosenOneUser(this, Users.SelectedItem.ToString());
        }
        public void ImaginateUser(User user) {
            UserName.Content = user.Name;
            UserBooks.ItemsSource = user.Books.Select(x => x.Name);
        }

        private void ClickBookSeek(object sender, RoutedEventArgs e) {
            BookSeeker(this, BookSearch.Text);
        }

        public void ImaginateBooks(List<Book> books) => LibBooks.ItemsSource = books.Select(x => x.Name);

        public void ImaginateUsers(List<User> users) => Users.ItemsSource = users.Select(x => x.Name);

        private void UserBookTheChosenOne_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            CurrentBookName.Content = UserBooks.SelectedItem;
            Type.Content = "Возврат";
        }

        private void LibBooks_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            CurrentBookName.Content = LibBooks.SelectedItem;
            Type.Content = "Выдача";
        }

        private void Run_Action(object sender, RoutedEventArgs e) {
            var nuser = UserName.Content;
            var nbook = CurrentBookName.Content;
            var ntype = Type.Content;
            if (null == nuser || null == nbook || null == ntype) {
                SynthesisError("входные данные плохо существуют");
                return;
            }
            var user = nuser.ToString();
            var book = nbook.ToString();
            var type = ntype.ToString();

            if ("" == user || "" == book || "" == type) {
                SynthesisError("входные данные пустоваты");
            } else {
                if ("Возврат" == type) {
                    TransferBook(this, (true, book.ToString(), user.ToString()));
                    return;
                }
                if ("Выдача" == type) {
                    TransferBook(this, (false, book.ToString(), user.ToString()));
                    return;
                }
                SynthesisError("не очень понятно, что надо сделать");
            }
        }

        public void RefreshLibBook(List<Book> books) => LibBooks.ItemsSource = books.Select(x => x.Name);

        public void RefreshUserBook(List<Book> books) => UserBooks.ItemsSource = books.Select(x => x.Name);

        private void DeselectClick(object sender, RoutedEventArgs e) {
            LibBooks.SelectedIndex = -1;
            UserBooks.SelectedIndex = -1;
        }

        private void ClickUserSeek(object sender, RoutedEventArgs e) {
            UserSeeker(this, UserSearch.Text);
        }
    }
}
