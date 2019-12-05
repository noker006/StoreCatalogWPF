using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using StoreCatalogWPF.ViewModels.GeneralVMs;
using StoreCatalogWPF.Models.Product.TypeProduct;
using StoreCatalogWPF.Models;


namespace StoreCatalogWPF.ViewModels
{
    class CatalogVM : ViewModel, INotifyPropertyChanged
    {
        public CatalogVM(string name,VMManager root):base(name,root)
        {
            catalog = new Catalog();
            VisibilityAudioEqupments = Visibility.Collapsed;
            ActualTypeProductList = new ObservableCollection<object>(catalog.acousticHiFis);
        }
        private Catalog catalog;

        private int selectedTypeProduct;
        public int SelectedTypeProduct
        {
            set
            {
                selectedTypeProduct = value;
                switch (selectedTypeProduct)
                {
                    case 0:
                        {
                            VisibilityAudioEqupments = Visibility.Visible;
                            break;
                        }
                    case 1:
                        {
                            
                            break;
                        }
                    case 2:
                        {
                         
                            break;
                        }
                    default:
                        break;
                }
                OnPropertyChanged("SelectedTypeProduct");
            }
            get
            {
                return selectedTypeProduct;
            }
        }

        private Visibility visibilityAudioEqupments;
        public Visibility VisibilityAudioEqupments
        {
            set
            {
                visibilityAudioEqupments = value;
                OnPropertyChanged("VisibilityAudioEqupments");
            }
            get
            {
                return visibilityAudioEqupments;
            }
        }

        private int selectedTypeAudio;
        public int SelectedTypeAudio
        {
            set
            {

                selectedTypeAudio = value;
                ActualMapingSubtypes = selectedTypeAudio;
                OnPropertyChanged("SelecteSubtypes");
            }
            get
            {
                return selectedTypeAudio;
            }
        }

        private int actualMapingSubtypes;
        public int ActualMapingSubtypes
        {
            set
            {
                actualMapingSubtypes = value;
                OnPropertyChanged("ActualMapingSubtypes");
            }
            get
            {
                return actualMapingSubtypes;
            }
        }

        private object actualSelectedProduct;

        public object ActualSelectedProduct
        {
            set
            {
                actualSelectedProduct = value;
                OnPropertyChanged("ActualSelectedProduct");
            }
            get
            {
                return actualSelectedProduct;
            }
        }

        private string producer;


        public ObservableCollection<object> ActualTypeProductList { set; get; }




        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop ="")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
