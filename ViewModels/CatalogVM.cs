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
            TitlesTypeProduct = new List<string> { "AudioEqupments", "Phone and gadgets", "Photo-Video Equpments" };
            TitlesAudioEquipment = new List<string> { "Acoustic HiFi", "MusicCentre", "Radio" };
            TitlesPhone_Phonegadget = new List<string> { "Phone", "SmartWatch" };
            TitlesPhotoVideoEquipment = new List<string> { "PhotoCamera", "VideoCamera" };
            visibilityAudioEquipment = Visibility.Collapsed;
            visibilityPhone_Phonegadget = Visibility.Collapsed;
            visibilityPhotoVideoEquipment = Visibility.Collapsed;
        }



        private Catalog catalog;


        private string selectedTypeProduct;
        private string selectedAudioEquipment;
        private string selectedPhone_Phonegadget;
        private string selectedPhotoVideoEquipment;


        private Visibility visibilityAudioEquipment;
        private Visibility visibilityPhone_Phonegadget;
        private Visibility visibilityPhotoVideoEquipment;


        public List<string>  TitlesTypeProduct { set; get; }
        public List<string> TitlesAudioEquipment { set; get; }
        public List<string> TitlesPhone_Phonegadget { set; get; }
        public List<string> TitlesPhotoVideoEquipment { set; get; }

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

        public string SelectedAudioEquipment
        {
            set
            {
                selectedAudioEquipment = value;
                switch (selectedAudioEquipment)
                {
                    case "Acoustic HiFi":
                        {
                            ActualListProducts = new ObservableCollection<object>(catalog.AcousticHiFis);
                            break;
                        }
                    case "MusicCentre":
                        {
                            break;
                        }
                    case "Radio":
                        {
                            break;
                        }
                    default:
                        break;
                }
                OnPropertyChanged("SelectedAudioEquipment");
            }
            get
            {
                return selectedAudioEquipment;
            }
        }

        public string SelectedPhone_Phonegadget
        {
            set
            {
                selectedPhone_Phonegadget = value;
                switch (selectedPhone_Phonegadget)
                {
                    case "Phone":
                        {
                            break;
                        }
                    case "SmartWatch":
                        {
                            break;
                        }
                    default:
                        break;
                }
                OnPropertyChanged("SelectedPhone_Phonegadget");
            }
            get
            {
                return selectedPhone_Phonegadget;
            }
        }

        public string SelectedPhotoVideoEquipment
        {
            set
            {
                selectedPhotoVideoEquipment = value;
                switch (selectedPhotoVideoEquipment)
                {
                    case "PhotoCamera":
                        {
                            ActualListProducts = new ObservableCollection<object>(catalog.PhotoCameras);
                            break;
                        }
                    case "VideoCamera":
                        {
                            break;
                        }
                    default:
                        break;
                }
                OnPropertyChanged("SelectedPhotoVideoEquipment");
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


        private ObservableCollection<object> actualListProducts;
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





        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop ="")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
