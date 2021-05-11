using System.Windows;
using System.Windows.Input;

namespace Penztargep_dr1_WPF.State.Navigators {
    public interface IWindowManager {
        Window Show<T>() where T : Window;
        WindowState Minimize(object window);
        WindowState Maximize(object window);
        WindowState Restore(object window);
        Window Close(object window);
        ICommand MinimizeWindowCommand { get; }
        ICommand ChangeWindowStateCommand { get; }
        ICommand CloseWindowCommand { get; }
    }
}
