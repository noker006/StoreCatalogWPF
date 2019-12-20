using System.ComponentModel;
using System.Runtime.CompilerServices;
using StoreCatalogWPF.RelCommand;
using StoreCatalogWPF.Models;
using StoreCatalogWPF.Models.Product;
using System.Windows;
using System;
using System.Collections.Generic;

namespace StoreCatalogWPF.ViewModels.GeneralVMs
{
    class BasicVM: MainVM,INotifyPropertyChanged
    {
        public static Catalog catalog=new Catalog();

        private RelayCommand command;
        public string Name { set; get; }
        public VMManager Root { set; get; }

        public BasicVM(string name, VMManager root)
        {
            Name = name;
            Root = root;
        }

        public object Next
        {
            get
            {
                return command ??
                    (command = new RelayCommand(obj =>
                    {
                        string needOpen = obj as string;
                        Root.NextWindow(needOpen);
                    }));
            }
        }
    }
}

