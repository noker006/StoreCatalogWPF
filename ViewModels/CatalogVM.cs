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
    class CatalogVM:BasicVM
    {
        public CatalogVM(string name, VMManager root) : base(name, root)
        {
            TitlesTypeProduct = new List<string> { "AudioEqupments", "Phone and gadgets", "Photo-Video Equpments" };
            SearchList = new List<string> { "Title", "ID", "Producer" };
            AudioEquipments = new List<object>(catalog.AllSubtypesAudioEquipment);
            Phones_Phonegadgets = new List<object>(catalog.AllSubtypesPhone_Phonegadget);
            PhotoVideoEquipments = new List<object>(catalog.AllSubtypesPhotoVideoEquipment);
            VisibilityAudioEquipment = Visibility.Collapsed;
            VisibilityPhone_Phonegadget = Visibility.Collapsed;
            VisibilityPhotoVideoEquipment = Visibility.Collapsed;
            VisibilityEditWeald = Visibility.Collapsed;
            VisibilitySearch = Visibility.Collapsed;
        }

        private GeneralProduct actualSelectedProduct;
        private object selectedAudioEquipment;
        private object selectedPhone_Phonegadget;
        private object selectedPhotoVideoEquipment;
        private string selectedTypeProduct;
        private string selectedProducer;
        private string selectedTypeSearch;
        private string desiredString;

        private RelayCommand sort;
        private RelayCommand delete;
        private RelayCommand edit;
        private RelayCommand done;
        private RelayCommand open;
        private RelayCommand save;
        private RelayCommand export;
        private RelayCommand import;

        private Visibility visibilityAudioEquipment;
        private Visibility visibilityPhone_Phonegadget;
        private Visibility visibilityPhotoVideoEquipment;
        private Visibility visibilityEditWeald;
        private Visibility visibilitySearch;

        private string minPrice;
        private string maxPrice;
        public List<string> TitlesTypeProduct { set; get; }
        public List<string> SearchList { set; get; }
        private ObservableCollection<GeneralProduct> actualListProducts;
        private List<string> producerList;
        private List<GeneralProduct> ExtendedSelectedProducts=new List<GeneralProduct>();

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
        public Visibility VisibilityEditWeald
        {
            set
            {
                visibilityEditWeald = value;
                OnPropertyChanged("VisibilityEditWeald");
            }
            get
            {
                return visibilityEditWeald;
            }
        }
        public Visibility VisibilitySearch
        {
            set
            {
                visibilitySearch = value;
                OnPropertyChanged("VisibilitySearch");
            }
            get
            {
                return visibilitySearch;
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
                VisibilitySearch = Visibility.Visible;
                ActualListProducts = new ObservableCollection<GeneralProduct>(catalog.GetRequiredList(selectedAudioEquipment));
                catalog.RealListProducts=new List<GeneralProduct>(catalog.GetRequiredList(selectedAudioEquipment));
                ProducerList = new List<string>(catalog.CreateListProducer(catalog.RealListProducts));
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
                VisibilitySearch = Visibility.Visible;
                ActualListProducts = new ObservableCollection<GeneralProduct>(catalog.GetRequiredList(selectedPhone_Phonegadget));
                catalog.RealListProducts= new List<GeneralProduct>(catalog.GetRequiredList(selectedPhone_Phonegadget));
                ProducerList = new List<string>(catalog.CreateListProducer(catalog.RealListProducts));
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
                VisibilitySearch = Visibility.Visible;
                ActualListProducts = new ObservableCollection<GeneralProduct>(catalog.GetRequiredList(selectedPhotoVideoEquipment));
                catalog.RealListProducts=new  List<GeneralProduct>(catalog.GetRequiredList(selectedAudioEquipment));
                ProducerList = new List<string>(catalog.CreateListProducer(catalog.RealListProducts));
                OnPropertyChanged("SelectedPhotoVideoEquipment");
            }
            get
            {
                return selectedPhotoVideoEquipment;
            }
        }


        public GeneralProduct ActualSelectedProduct
        {
            set
            {
                actualSelectedProduct = value;
                ExtendedSelectedProducts.Add(actualSelectedProduct);
                OnPropertyChanged("ActualSelectedProduct");
            }
            get
            {
                return actualSelectedProduct;
            }
        }

        public string SelectedTypeSearch
        {
            set
            {
                selectedTypeSearch = value;
                catalog.ActualTypeSearch = selectedTypeSearch;
                OnPropertyChanged("SelectedTypeSort");
            }
            get
            {
                return selectedTypeSearch;
            }
        }

        public string DesiredString
        {
            set
            {
                desiredString = value;
                ActualListProducts=new ObservableCollection<GeneralProduct>(catalog.Search(desiredString, catalog.RealListProducts));
                OnPropertyChanged("DesiredString");
            }
            get
            {
                return desiredString;
            }
        }
        public string SelectedProducer
        {
            set
            {
                selectedProducer = value;
                catalog.RequiredProducer = selectedProducer;
                OnPropertyChanged("SelecetdProducer");
            }
            get => selectedProducer;
        }
        public List<object> AudioEquipments { set; get; }
        public List<object> Phones_Phonegadgets { set; get; }
        public List<object> PhotoVideoEquipments { set; get; }
        public List<string> ProducerList
        {
            set
            {
                producerList = value;
                OnPropertyChanged("ProducerList");
            }
            get
            {
                return producerList;
            }
        }
        public ObservableCollection<GeneralProduct> ActualListProducts
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

        public string MinPrice
        {
            set
            {
                minPrice = value;
                if (minPrice != "")
                {
                    catalog.MinPrice = Convert.ToDouble(minPrice);
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
                }
                OnPropertyChanged("MaxPrice");
            }
            get
            {
                return maxPrice;
            }
        }

        public RelayCommand Sort
        {
            get
            {
                return sort ??
                  (sort = new RelayCommand(obj =>
                  {
                      ActualListProducts = new ObservableCollection<GeneralProduct>(catalog.GeneralSort(catalog.RealListProducts));
                  }));
            }
        }
        
        public RelayCommand Edit
        {
            get
            {
                return edit ??
                  (edit = new RelayCommand(obj =>
                  {
                      VisibilityEditWeald = Visibility.Visible;
                  }));
            }
        }

        public RelayCommand Delete
        {
            get
            {
                return delete ??
                  (delete = new RelayCommand(obj =>
                  {
                      catalog.DeleteProduct(ActualSelectedProduct);
                      catalog.RealListProducts = new List<GeneralProduct>(catalog.GetRequiredList(ActualSelectedProduct));
                      ActualListProducts = new ObservableCollection<GeneralProduct>(catalog.GetRequiredList(ActualSelectedProduct));
                  }));
            }
        }

        public RelayCommand Done
        {
            get
            {
                return done ??
                  (done = new RelayCommand(obj =>
                  {
                      VisibilityEditWeald = Visibility.Collapsed;
                  }));
            }
        }

        public RelayCommand Open
        {
            get
            {
                return open ??
                  (open = new RelayCommand(obj =>
                  {
                      catalog.Open();
                  }));
            }
        } 

        public RelayCommand Save
        {
            get
            {
                return save ??
                  (save = new RelayCommand(obj =>
                  {
                      if (catalog.CatalogOpen)
                      {
                          //catalog.Save();
                      }
                  }));
            }
        }

        public RelayCommand Export
        {
            get
            {
                return export ??
                  (export = new RelayCommand(obj =>
                  {
                      if (catalog.CatalogOpen)
                      {
                          catalog.Export();
                          Root.CurrentVM = new IDExeptionVM("IDExeptionVM", Root);
                      }
                  }));
            }
        }

        public RelayCommand Import 
        {
            get
            {
                return import ??
                  (import = new RelayCommand(obj =>
                  {
                      if (catalog.CatalogOpen)
                      {
                          catalog.Import();
                          Root.CurrentVM = new IDExeptionVM("IDExeptionVM", Root);
                      }
                  }));
            }
        }

        private RelayCommand saveAs;
        
        private RelayCommand SaveAs
        {
            get
            {
                return saveAs ??
                  (saveAs = new RelayCommand(obj =>
                  {
                      if (catalog.CatalogOpen)
                      {
                          catalog.SaveAs();
                      }
                  }));
            }
        }
    }
}
