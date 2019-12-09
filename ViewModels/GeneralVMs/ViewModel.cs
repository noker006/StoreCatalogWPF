using System.ComponentModel;
using System.Runtime.CompilerServices;
using StoreCatalogWPF.RelCommand;

namespace StoreCatalogWPF.ViewModels.GeneralVMs
{
    class ViewModel : INotifyPropertyChanged
    {
        private RelayCommand _command;
        public string Name { set; get; }
        public VMManager Root { set; get; }

        public ViewModel(string name, VMManager root)
        {
            Name = name;
            Root = root;
        }

        public object GoTo
        {
            get
            {
                return _command ??
                    (_command = new RelayCommand(obj =>
                    {
                        string needOpen = obj as string;
                        Root.GoToWindow(needOpen);
                    }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

