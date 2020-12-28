using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace Liblaly.View {
    /// <summary>
    /// Interaction logic for UserManageView.xaml
    /// </summary>
    public partial class UserManageView : Window {
        public event EventHandler<string> UserSeeker = delegate { };
        public event EventHandler<string> UserDestroyer = delegate { };
        public event EventHandler<(string, string)> UserImaginator = delegate { };
        public event EventHandler<string> TheChosenOne = delegate { };
        public event EventHandler Fresh = delegate { };
        public UserManageView() {
            InitializeComponent();
        }
        public void SynthesisUniverseUsers(List<User> users, long creationTime) {
            Users.ItemsSource = users
                .Select(x => x.Name);
            Users.Items.Refresh();
        }
        public void SynthesisError(string err) => new Error(err) { Owner = this }.Show();

        private void DeleteUserClick(object sender, RoutedEventArgs e) {
            var b = Users.SelectedItem.ToString();
            UserDestroyer(this, b);
        }

        private void CreateUserClick(object sender, RoutedEventArgs e) {
            UserImaginator(this, (UserName.Text, Date.Text));
        }

        private void SeekUser(object sender, RoutedEventArgs e) {
            UserSeeker(this, UserSeek.Text);
        }

        private void Users_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            TheChosenOne(this, Users.SelectedItem == null ? "" : Users.SelectedItem.ToString());
        }

        public void DrawUser(User user) {
            CurrentUserName.Text = user.Name;
            CurrentUserDead.Text = new DateTime(user.Deadline).ToShortDateString();
        }

        private void Refresh(object sender, RoutedEventArgs e) {
            Fresh(this, e);
        }
    }
}
