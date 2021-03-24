using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Penztargep_dr1_WPF.ViewModels {
    public class ViewModelBase : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
