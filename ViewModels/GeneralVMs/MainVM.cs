using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StoreCatalogWPF.ViewModels.GeneralVMs
{
    abstract class MainVM:INotifyPropertyChanged 
    {
        protected object _currentVM;
        protected List<ViewModel> _viewModels;

        public MainVM()
        {
            _viewModels = new List<ViewModel>();
        }

        public void GoToWindow(string NeedSuchViewModel)
        {
            for (int i = 0; i < _viewModels.Count; i++)
            {
                if (_viewModels[i].Name == NeedSuchViewModel)
                {
                    _currentVM = _viewModels[i];
                    break;
                }
                else
                    _currentVM = this;
            }
            OnPropertyChanged("CurrentVM");
        }

        public void AddVM(ViewModel newVM)
        {
            if (_viewModels == null)
                _viewModels = new List<ViewModel>();
            _viewModels.Add(newVM);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

