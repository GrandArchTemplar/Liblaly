using System.Windows;

namespace Liblaly.View {
    /// <summary>
    /// Interaction logic for Error.xaml
    /// </summary>
    public partial class Error : Window {
        public Error(string err) {
            InitializeComponent();
            ErrorName.Text = err;
        }

        private void CloseClick(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
