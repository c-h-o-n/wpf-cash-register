using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Penztargep_dr1_WPF.Services {
    public interface IWindowService {
        void ShowWindow(Window targetView, object viewModel);
        void MinimizeWindow();
        void ChangeWindowState();
        void CloseWindow();
        ICommand MinimizeWindowCommand { get; }
        ICommand ChangeWindowStateCommand { get; }
        ICommand CloseWindowCommand { get; }
    }
}
