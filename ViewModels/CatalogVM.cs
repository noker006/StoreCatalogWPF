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
            //VisibilityAudioEqupments = Visibility.Collapsed;
            //VisibilityPhone_Gadgets = Visibility.Collapsed;
        }
        private Catalog catalog;
        //private Visibility visibilityAudioEqupments;
        //private Visibility visibilityPhone_Gadgets;
        //private Visibility visibilityPhotoVideoEquipments;

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
                            //VisibilityAudioEqupments = Visibility.Visible;
                            break;
                        }
                    case 1:
                        {
                            //VisibilityPhone_Gadgets = Visibility.Visible;
                            break;
                        }
                    case 2:
                        {
                            //VisibilityPhotoVideoEquipments = Visibility.Visible;
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

        //public Visibility VisibilityAudioEqupments
        //{
        //    set
        //    {
        //        visibilityAudioEqupments = value;
        //        if (value != Visibility.Collapsed)
        //        {
        //            VisibilityPhone_Gadgets = Visibility.Collapsed;
        //            VisibilityPhotoVideoEquipments = Visibility.Collapsed;
        //        }
        //        OnPropertyChanged("VisibilityAudioEqupments");
        //    }
        //    get
        //    {
        //        return visibilityAudioEqupments;
        //    }
        //}


        //public Visibility VisibilityPhone_Gadgets
        //{
        //    set
        //    {
        //        visibilityPhone_Gadgets = value;
        //        VisibilityAudioEqupments = Visibility.Collapsed;
        //        VisibilityPhotoVideoEquipments = Visibility.Collapsed;
        //        OnPropertyChanged("VisibilityPhone_Gadgets");
        //    }
        //    get
        //    {
        //        return visibilityPhone_Gadgets;
        //    }
        //}


        //public Visibility VisibilityPhotoVideoEquipments
        //{
        //    set
        //    {
        //        visibilityPhotoVideoEquipments = value;
        //        VisibilityAudioEqupments = Visibility.Collapsed;
        //        VisibilityPhone_Gadgets = Visibility.Collapsed;
        //        OnPropertyChanged("VisibilityPhotoVideoEquipments");
        //    }
        //    get
        //    {
        //        return visibilityPhotoVideoEquipments;
        //    }
        //}

        private int selectedAudioEqupment;
        
        public int SelectedAudioEqupment
        {
            set
            {
                selectedAudioEqupment = value;
                switch (selectedTypeProduct)
                {
                    case 0:
                        {
                            ActualListProducts = new ObservableCollection<object>(catalog.AcousticHiFis);
                            break;
                        }
                    case 1:
                        {
                            ActualListProducts = new ObservableCollection<object>(catalog.MusicCentres);
                            break;
                        }
                    case 2:
                        {
                            ActualListProducts = new ObservableCollection<object>(catalog.Radios);
                            break;
                        }
                    default:
                        break;
                }
            }
            get
            {
                return selectedAudioEqupment;
            }
        }

        private int selectedPhotoVideoEquipment;

        public int SelectedPhotoVideoEquipment
        {
            set
            {
                selectedPhotoVideoEquipment = value;
                switch (selectedTypeProduct)
                {
                    case 0:
                        {
                            ActualListProducts = new ObservableCollection<object>(catalog.PhotoCameras);
                            break;
                        }
                    case 1:
                        {
                            ActualListProducts = new ObservableCollection<object>(catalog.videoCameras);
                            break;
                        }
                    default:
                        break;
                }
            }
            get
            {
                return selectedPhotoVideoEquipment;
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

        public ObservableCollection<object> ActualListProducts { set; get; }




        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop ="")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
