using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StoreCatalogWPF.ViewModels.GeneralVMs;
using StoreCatalogWPF.Models.Product.TypeProduct;
using StoreCatalogWPF.Models;

namespace StoreCatalogWPF.ViewModels
{
    class CatalogVM : ViewModel, INotifyPropertyChanged
    {
        public CatalogVM(string name,VMManager root):base(name,root)
        {
            SelectedTypeProduct = 1000;
        }
        private Catalog catalog = new Catalog();

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
                            ActualMapingTypeProduct = catalog.audio;
                            break;
                        }
                    case 1:
                        {
                            ActualMapingTypeProduct = catalog.photoVideo;
                            break;
                        }
                    case 2:
                        {
                            ActualMapingTypeProduct = catalog.phone_gadget;
                            break;
                        }
                    default:
                        break;
                }
                OnPropertyChanged("SelectedType");
            }
            get
            {
                return selectedTypeProduct;
            }
        }

        private string selectedTypeAudio;
        public string SelectedTypeAudio
        {
            set
            {

                selectedTypeAudio = value;
                switch (selectedTypeAudio)
                {
                    case "s":
                        {
                            ActualMapingSubtypes = catalog.acousticHiFis;
                            break;
                        }
                    case "sa":
                        {
                            ActualMapingSubtypes = catalog.musicCentre;
                            break;
                        }
                    case "syka":
                        {
                            ActualMapingSubtypes = catalog.radio;
                            break;
                        }
                    default:
                        break;
                }
                OnPropertyChanged("SelecteSubtypes");
            }
            get
            {
                return selectedTypeAudio;
            }
        }


        private object actualMapingTypeProduct;
        public object ActualMapingTypeProduct
        {
            set
            {
                actualMapingTypeProduct = value;
                OnPropertyChanged("ActualMapingTypeProduct");
            }
            get
            {
                return actualMapingTypeProduct;
            }
        }

        private object actualMapingSubtypes;
        public object ActualMapingSubtypes
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop ="")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
