using System.Windows;

namespace Penztargep_dr1_WPF.Views {
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window {
        public LoginView(object dataContext) {
            InitializeComponent();

            DataContext = dataContext;

        }
    }
}
