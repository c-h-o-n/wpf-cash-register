using System.Windows;

namespace Penztargep_dr1_WPF.Views {
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window {
        public MainView(object dataContext) {
            InitializeComponent();

            DataContext = dataContext;
        }
    }
}
