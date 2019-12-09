using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using StoreCatalogWPF.ViewModels.GeneralVMs;
using System.ComponentModel;
using StoreCatalogWPF.Models;
using StoreCatalogWPF.RelCommand;
using StoreCatalogWPF.Models.Product;

namespace StoreCatalogWPF.ViewModels
{
    class AddProductVM : ViewModel
    {
        public AddProductVM(string name, VMManager root) : base(name, root)
        {
            catalog = new Catalog();
            TitlesTypeProduct = new List<string> { "AudioEqupments", "Phone and gadgets", "Photo-Video Equpments" };
            AudioEquipments = new List<object>(catalog.AllSubtypesAudioEquipment);
            Phones_Phonegadgets = new List<object>(catalog.AllSubtypesPhone_Phonegadget);
            PhotoVideoEquipments = new List<object>(catalog.AllSubtypesPhotoVideoEquipment);
        }
        private Catalog catalog;

        private object actualSelectedProduct;

        private string selectedTypeProduct;
        private object selectedAudioEquipment;
        private object selectedPhone_Phonegadget;
        private object selectedPhotoVideoEquipment;


        private Visibility visibilityAudioEquipment;
        private Visibility visibilityPhone_Phonegadget;
        private Visibility visibilityPhotoVideoEquipment;


        public List<string> TitlesTypeProduct { set; get; }
        public List<object> AudioEquipments { set; get; }
        public List<object> Phones_Phonegadgets { set; get; }
        public List<object> PhotoVideoEquipments { set; get; }


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
                    default: break;
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
                ActualSelectedProduct = selectedAudioEquipment;
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
                ActualSelectedProduct = selectedPhone_Phonegadget;
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
                ActualSelectedProduct = selectedPhotoVideoEquipment;
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

        private RelayCommand save;
        public RelayCommand Save
        {
            get
            {
                return save ??
                  (save = new RelayCommand(obj =>
                  {
                      catalog.allProducts.Add((GeneralProduct)ActualSelectedProduct);
                  }));
            }
        }

    }
}
