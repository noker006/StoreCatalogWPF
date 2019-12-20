using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StoreCatalogWPF.ViewModels.GeneralVMs
{
    abstract class MainVM : INotifyPropertyChanged
    {
        protected object currentVM;
        static protected List<BasicVM> viewModels = new List<BasicVM>();

        public void NextWindow(string NeedSuchViewModel)
        {
            for (int i = 0; i < viewModels.Count; i++)
            {
                if (viewModels[i].Name == NeedSuchViewModel)
                {
                    currentVM = viewModels[i];
                    break;
                }
                else
                currentVM = this;
            }
            OnPropertyChanged("CurrentVM");
        }

        public void AddVM(BasicVM newVM)
        {
            if (viewModels == null)
                viewModels = new List<BasicVM>();
            viewModels.Add(newVM);
        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

