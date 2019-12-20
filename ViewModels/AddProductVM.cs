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
    class AddProductVM:BasicVM
    {
        public AddProductVM(string name,VMManager root) :base(name,root)
        {
            TitlesTypeProduct = new List<string> { "AudioEqupments", "Phone and gadgets", "Photo-Video Equpments" };
            AudioEquipments = new List<object>(catalog.AllSubtypesAudioEquipment);
            Phones_Phonegadgets = new List<object>(catalog.AllSubtypesPhone_Phonegadget);
            PhotoVideoEquipments = new List<object>(catalog.AllSubtypesPhotoVideoEquipment);
            visibilityAudioEquipment = Visibility.Collapsed;
            visibilityPhone_Phonegadget = Visibility.Collapsed;
            visibilityPhotoVideoEquipment = Visibility.Collapsed;
        }

        private GeneralProduct actualSelectedProduct;

        private string selectedTypeProduct;
        private GeneralProduct selectedAudioEquipment;
        private GeneralProduct selectedPhone_Phonegadget;
        private GeneralProduct selectedPhotoVideoEquipment;


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

        private void AddMessage()
        {
            MessageBoxResult add = MessageBox.Show("Product Added");
        }
        private void NoAddMessage()
        {
            MessageBoxResult Noadd = MessageBox.Show("Product not added,this id is already exists");
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
                ActualSelectedProduct = selectedAudioEquipment;
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
                ActualSelectedProduct = selectedPhone_Phonegadget;
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
                ActualSelectedProduct = selectedPhotoVideoEquipment;
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
                actualSelectedProduct = catalog.CreateNewObject(value);
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
                      int counter = 0;
                      for (int i = 0; i < catalog.Products.Count; i++)
                      {
                          if (ActualSelectedProduct.ID == catalog.Products[i].ID)
                          {
                              counter++;
                              break;
                          }
                      } 
                      if (counter == 0)
                      {
                         catalog.AddProduct(ActualSelectedProduct);
                         ActualSelectedProduct = catalog.CreateNewObject(ActualSelectedProduct);
                         AddMessage();
                      }
                      else
                      {
                         NoAddMessage();
                      }
                  }));
            }
        }

    }
}
