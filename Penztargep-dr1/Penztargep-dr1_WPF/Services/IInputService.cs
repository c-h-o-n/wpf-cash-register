﻿using System.Windows.Input;

namespace Penztargep_dr1_WPF.Services {
    public interface IInputService {
        string CurrentInput { get; set; }
        ICommand InputKeyCommand { get; }
        ICommand ProductClickCommand { get; }
        int[] SplitInput(string InputString);

    }
}
