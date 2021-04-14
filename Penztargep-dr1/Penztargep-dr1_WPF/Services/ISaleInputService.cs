using Penztargep_dr1_Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Penztargep_dr1_WPF.Services {
    public interface ISaleInputService {
        string CurrentInput { get; set; }
        ICommand InputKeyCommand { get; }
        int[] SplitInput(string InputString);

    }
}
