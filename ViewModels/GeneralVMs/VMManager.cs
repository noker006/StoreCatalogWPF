using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreCatalogWPF.ViewModels;
using StoreCatalogWPF.Models;

namespace StoreCatalogWPF.ViewModels.GeneralVMs
{
    class VMManager:MainVM
    {
        
        public VMManager()
        {           
            AddVM(new CatalogVM("CatalogVM", this));
            AddVM(new AddProductVM("AddProductVM", this));
        }

        public object CurrentVM
        {
            get
            {
                if (_currentVM == null)
                {
                    _currentVM = _viewModels[0];
                    CurrentVM = _currentVM;
                }

                if (_currentVM == this)
                {
                    System.Windows.Application.Current.Shutdown();
                }

                return _currentVM;
            }
            set
            {
                _currentVM = value;
                OnPropertyChanged("CurrentVM");
            }
        }
    }
}

