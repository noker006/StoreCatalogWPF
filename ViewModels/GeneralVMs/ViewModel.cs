
using StoreCatalogWPF.RelCommand;

namespace StoreCatalogWPF.ViewModels.GeneralVMs
{
    class ViewModel
    {
        protected RelayCommand _command;
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
    }
}

