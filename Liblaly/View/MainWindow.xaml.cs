using Liblaly.Presenter;
using Liblaly.View;
using System;
using System.Windows;

namespace Liblaly {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        readonly Model model;
        public event EventHandler Save = delegate { };
        public MainWindow() {
            InitializeComponent();
            model = new Model();
        }

        private void BookManage(object sender, RoutedEventArgs e) {
            var view = new BookManageView();
            new BookPresenter(view, model);
            view.Owner = this;
            view.Show();
        }

        private void UserBookManage(object sender, RoutedEventArgs e) {
            var view = new UserBookManageView();
            new UserBookPresenter(view, model);
            view.Owner = this;
            view.Show();
        }

        private void UserManage(object sender, RoutedEventArgs e) {
            var view = new UserManageView();
            new UserPresenter(view, model);
            view.Owner = this;
            view.Show();
        }

        private void SaveClick(object sender, RoutedEventArgs e) {
            new SavePresenter(this, model);
            Save(this, e);
        }
    }
}
