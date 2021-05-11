using System.Windows;

namespace Penztargep_dr1_WPF.Views {
    /// <summary>
    /// Interaction logic for RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : Window {
        public RegistrationView(object dataContext) {
            InitializeComponent();

            DataContext = dataContext;
        }
    }
}
