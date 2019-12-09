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
using StoreCatalogWPF.Models.Product;
using StoreCatalogWPF.Models;
using StoreCatalogWPF.RelCommand;


namespace StoreCatalogWPF.ViewModels
{
    class CatalogVM : ViewModel
    {
        public CatalogVM(string name,VMManager root):base(name,root)
        {
            TitlesTypeProduct = new List<string> { "AudioEqupments", "Phone and gadgets", "Photo-Video Equpments" };
            AudioEquipments = new List<object>(catalog.AllSubtypesAudioEquipment);
            Phones_Phonegadgets = new List<object>(catalog.AllSubtypesPhone_Phonegadget);
            PhotoVideoEquipments = new List<object>(catalog.AllSubtypesPhotoVideoEquipment);
            visibilityAudioEquipment = Visibility.Collapsed;
            visibilityPhone_Phonegadget = Visibility.Collapsed;
            visibilityPhotoVideoEquipment = Visibility.Collapsed;
        }

        private string selectedTypeProduct;
        private object selectedAudioEquipment;
        private object selectedPhone_Phonegadget;
        private object selectedPhotoVideoEquipment;


        private Visibility visibilityAudioEquipment;
        private Visibility visibilityPhone_Phonegadget;
        private Visibility visibilityPhotoVideoEquipment;


        private object actualSelectedProduct;



        private string minPrice;
        private string maxPrice;

        public List<string>  TitlesTypeProduct { set; get; }

        private ObservableCollection<object> actualListProducts;

        private List<GeneralProduct> realListProducts;

        public Visibility VisibilityAudioEquipment
        {
            set
            {
                visibilityAudioEquipment = value;
                OnPropertyChanged("VisibilityAudioEquipment");
            }
            get
            {
                return visibilityAudioEquipment;
            }
        }

        public Visibility VisibilityPhone_Phonegadget
        {
            set
            {
                visibilityPhone_Phonegadget = value;
                OnPropertyChanged("VisibilityPhone_Phonegadget");
            }
            get
            {
                return visibilityPhone_Phonegadget;
            }
        }

        public Visibility VisibilityPhotoVideoEquipment
        {
            set
            {
                visibilityPhotoVideoEquipment = value;
                OnPropertyChanged("VisibilityPhotoVideoEquipment");
            }
            get
            {
                return visibilityPhotoVideoEquipment;
            }
        }


        public string SelectedTypeProduct
        {
            set
            {
                selectedTypeProduct = value;
                switch (selectedTypeProduct)
                {
                    case "AudioEqupments":
                        {
                            VisibilityPhone_Phonegadget = Visibility.Collapsed;
                            VisibilityPhotoVideoEquipment = Visibility.Collapsed;
                            VisibilityAudioEquipment = Visibility.Visible;
                            break;
                        }
                    case "Phone and gadgets":
                        {
                            VisibilityAudioEquipment = Visibility.Collapsed;
                            VisibilityPhotoVideoEquipment = Visibility.Collapsed;
                            VisibilityPhone_Phonegadget = Visibility.Visible;
                            break;
                        }
                    case "Photo-Video Equpments":
                        {
                            VisibilityPhone_Phonegadget = Visibility.Collapsed;
                            VisibilityAudioEquipment = Visibility.Collapsed;
                             VisibilityPhotoVideoEquipment = Visibility.Visible;
                            break;
                        }
                    default:break;
                }
                OnPropertyChanged("SelectedTypeProduct");
            }
            get
            {
                return selectedTypeProduct;
            }
        }

        public object SelectedAudioEquipment
        {
            set
            {
                selectedAudioEquipment = value;
                ActualListProducts = new ObservableCollection<object>(catalog.GetRequiredList(selectedAudioEquipment));
                RealListProducts=new List<GeneralProduct>(catalog.GetRequiredList(selectedAudioEquipment));
                OnPropertyChanged("SelectedAudioEquipment");
            }
            get
            {
                return selectedAudioEquipment;
            }
        }

        public object SelectedPhone_Phonegadget
        {
            set
            {
                selectedPhone_Phonegadget = value;
                ActualListProducts = new ObservableCollection<object>(catalog.GetRequiredList(selectedPhone_Phonegadget));
                RealListProducts= new List<GeneralProduct>(catalog.GetRequiredList(selectedPhone_Phonegadget));
                OnPropertyChanged("SelectedPhone_Phonegadget");
            }
            get
            {
                return selectedPhone_Phonegadget;
            }
        }

        public object SelectedPhotoVideoEquipment
        {
            set
            {
                selectedPhotoVideoEquipment = value;
                ActualListProducts = new ObservableCollection<object>(catalog.GetRequiredList(selectedPhotoVideoEquipment));
                RealListProducts=new  List<GeneralProduct>(catalog.GetRequiredList(selectedAudioEquipment));
                OnPropertyChanged("SelectedPhotoVideoEquipment");
            }
            get
            {
                return selectedPhotoVideoEquipment;
            }
        }



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


        public List<object> AudioEquipments { set; get; }
        public List<object> Phones_Phonegadgets { set; get; }
        public List<object> PhotoVideoEquipments { set; get; }

        public ObservableCollection<object> ActualListProducts
        {
            set
            {
                actualListProducts = value;
                OnPropertyChanged("ActualListProducts");
            }
            get
            {
                return actualListProducts;
            }
        }

        public List<GeneralProduct> RealListProducts
        {
            set
            {
                realListProducts = value;
                OnPropertyChanged("RealListProducts");
            }
            get
            {
                return realListProducts;
            }
        }

        public string MinPrice
        {
            set
            {
                minPrice = value;
                if (minPrice != "")
                {
                    catalog.MinPrice = Convert.ToDouble(minPrice);
                    ActualListProducts = new ObservableCollection<object>(catalog.PriceSort(RealListProducts));
                }
                OnPropertyChanged("MinPrice");
            }
            get
            {
                return minPrice;
            }
        }

        public string MaxPrice
        {
            set
            {
                maxPrice = value;
                if (maxPrice != "")
                {
                    catalog.MaxPrice = Convert.ToDouble(maxPrice);
                    ActualListProducts = new ObservableCollection<object>(catalog.PriceSort(RealListProducts));
                }
                OnPropertyChanged("MaxPrice");
            }
            get
            {
                return maxPrice;
            }
        }

        private RelayCommand sort;
        public RelayCommand Sort
        {
            get
            {
                return sort ??
                  (sort = new RelayCommand(obj =>
                  {
                      
                  }));
            }
        }

    }
}
