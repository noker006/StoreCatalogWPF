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
        private GeneralProduct selectedAudioEquipment;
        private GeneralProduct selectedPhone_Phonegadget;
        private GeneralProduct selectedPhotoVideoEquipment;
        private string selectedTypeProduct;
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
        private string minCapasity;
        private string maxCapasity;
        private string selectedProducer;
        private List<string> producerList;
        private string selectedUpperFrequencyRange;
        private List<int> upperFrequencyRange;


        public List<int> UpperFrequencyRange
        {
            set
            {
                upperFrequencyRange = value;
                OnPropertyChanged();
            }
            get => upperFrequencyRange;
        }
        public List<string> ProducerList
        {
            set
            {
                producerList = value;
                OnPropertyChanged();
            }
            get => producerList;
        }
        public string SelectedProducer
        {
            set
            {
                selectedProducer = value;
                OnPropertyChanged();
            }
            get => selectedProducer;
        }

        private string MaxCapacity
        {
            set
            {
                maxCapasity = value;
                catalog.MaxCapasity =Convert.ToDouble(maxCapasity);
                OnPropertyChanged();
            }
            get => maxCapasity;
        }
        private string MinCapacity
        {
            set
            {
                minCapasity = value;
                catalog.MinCapasity = Convert.ToDouble(minCapasity);
                OnPropertyChanged();
            }
            get => minCapasity;
        }
        public string SelectedUpperFrequencyRange
        {
            set
            {
                selectedUpperFrequencyRange = value;
                catalog.UpperFrequencyRange = Convert.ToDouble(selectedUpperFrequencyRange);
                OnPropertyChanged();
            }
            get => selectedUpperFrequencyRange;
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



        public List<string> TitlesTypeProduct { set; get; }
        public List<string> SearchList { set; get; }
        private ObservableCollection<GeneralProduct> actualCollectionProducts;

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
                    default: break;
                }
                OnPropertyChanged("SelectedTypeProduct");
            }
            get
            {
                return selectedTypeProduct;
            }
        }

        public GeneralProduct SelectedAudioEquipment
        {
            set
            {
                selectedAudioEquipment = value;
                VisibilitySearch = Visibility.Visible;
                ActualCollectionProducts = catalog.CreateActualCollection(selectedAudioEquipment);
                catalog.CreateRealCollection(ActualCollectionProducts);
                ProducerList = catalog.CreateProducerList(selectedAudioEquipment);
                UpperFrequencyRange = catalog.CreateUpperFrequencyRangeList(SelectedAudioEquipment);
                catalog.ActualSelectedType = SelectedAudioEquipment;
                OnPropertyChanged("SelectedAudioEquipment");
            }
            get
            {
                return selectedAudioEquipment;
            }
        }

        public GeneralProduct SelectedPhone_Phonegadget
        {
            set
            {
                selectedPhone_Phonegadget = value;
                VisibilitySearch = Visibility.Visible;
                ActualCollectionProducts = catalog.CreateActualCollection(selectedPhone_Phonegadget);
                catalog.CreateRealCollection(ActualCollectionProducts);
                ProducerList=catalog.CreateProducerList(selectedAudioEquipment);
                catalog.ActualSelectedType = SelectedAudioEquipment;
                OnPropertyChanged("SelectedPhone_Phonegadget");
            }
            get
            {
                return selectedPhone_Phonegadget;
            }
        }

        public GeneralProduct SelectedPhotoVideoEquipment
        {
            set
            {
                selectedPhotoVideoEquipment = value;
                VisibilitySearch = Visibility.Visible;
                ActualCollectionProducts = catalog.CreateActualCollection(selectedPhotoVideoEquipment);
                catalog.CreateRealCollection(ActualCollectionProducts);
                ProducerList = catalog.CreateProducerList(selectedAudioEquipment);
                catalog.ActualSelectedType = SelectedAudioEquipment;
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
                ActualCollectionProducts=catalog.Search(desiredString);
                OnPropertyChanged("DesiredString");
            }
            get
            {
                return desiredString;
            }
        }
        public List<object> AudioEquipments { set; get; }
        public List<object> Phones_Phonegadgets { set; get; }
        public List<object> PhotoVideoEquipments { set; get; }
        public ObservableCollection<GeneralProduct> ActualCollectionProducts
        {
            set
            {
                actualCollectionProducts = value;
                OnPropertyChanged("ActualCollectionProducts");
            }
            get
            {
                return actualCollectionProducts;
            }
        }
        public RelayCommand Sort
        {
            get
            {
                return sort ??
                  (sort = new RelayCommand(obj =>
                  {
                     catalog.GeneralSort(ActualCollectionProducts);
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
                      if (VisibilityEditWeald == Visibility.Visible) VisibilityEditWeald = Visibility.Collapsed;
                      else VisibilityEditWeald = Visibility.Visible;
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
                      catalog.DeleteProduct(ActualSelectedProduct,ActualCollectionProducts);
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
                     if(catalog.ActualSelectedType != null) SelectedAudioEquipment = catalog.ActualSelectedType;
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
                         catalog.Save();
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
                          if(catalog.SameId_DifferentProduct) Root.CurrentVM = new IDExeptionVM("IDExeptionVM", Root);
                      }
                  }));
            }
        }
        public RelayCommand Import //переходит в Exeption в любом случае
        {
            get
            {
                return import ??
                  (import = new RelayCommand(obj =>
                  {
                      if (catalog.CatalogOpen)
                      {
                          catalog.Import();
                          if (catalog.SameId_DifferentProduct==true&&catalog.ExportImportProducts!=null) Root.CurrentVM = new IDExeptionVM("IDExeptionVM", Root);
                          if (catalog.ActualSelectedType != null) SelectedAudioEquipment = catalog.ActualSelectedType;
                      }
                  }));
            }
        }

        private RelayCommand saveAs;
        public RelayCommand SaveAs
        {
            get
            {
                return saveAs ??
                  (saveAs = new RelayCommand(obj =>
                  {
                        catalog.SaveAs();                     
                  }));
            }
        }
    }
}
