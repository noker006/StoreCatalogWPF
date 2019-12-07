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

namespace StoreCatalogWPF.ViewModels
{
    class AddProductVM : ViewModel,INotifyPropertyChanged
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
                OnPropertyChanged("SelectedPhotoVideoEquipment");
            }
            get
            {
                return selectedPhotoVideoEquipment;
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
