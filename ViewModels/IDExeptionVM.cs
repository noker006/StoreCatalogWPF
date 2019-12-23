using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreCatalogWPF.ViewModels.GeneralVMs;
using StoreCatalogWPF.Models.Product;
using StoreCatalogWPF.RelCommand;
using System.Windows;
using System.Collections.ObjectModel;
namespace StoreCatalogWPF.ViewModels
{
    class IDExeptionVM:BasicVM
    {
        public IDExeptionVM(string name, VMManager root):base(name, root)
        {
            SameIDProductsList = catalog.CreateSameIDProductsList();
            ExistingIDList = catalog.CreateExistingIDList();
        }

       private ObservableCollection<GeneralProduct> sameIDProductsList;
       private ObservableCollection<GeneralProduct> existingIDList;//хранятся только ID
        public ObservableCollection<GeneralProduct> SameIDProductsList
        {
            set
            {
                sameIDProductsList = value;
                OnPropertyChanged("SameIDProductsList");
            }
            get
            {
                return sameIDProductsList;
            }
        }
        public ObservableCollection<GeneralProduct> ExistingIDList
        {
            set
            {
                existingIDList = value;
                OnPropertyChanged("ExistingIDList");
            }
            get
            {
                return existingIDList;
            }
        }

        private GeneralProduct selectedSameIDProduct;
        public GeneralProduct SelectedSameIDProduct
        {
            set
            {
                selectedSameIDProduct = value;
                OnPropertyChanged("SelectedSameIDProduct");
            }
            get
            {
                return selectedSameIDProduct;
            }
        }

        private int iD;
        public int ID
        {
            set
            {
                iD = value;
                ExistingIDList = catalog.IDSearch(Convert.ToString(ID));
                OnPropertyChanged("Id");
            }
            get => iD;
        }

        private RelayCommand newId;
        public RelayCommand NewId
        {
            get
            {
                return newId ??
                  (newId = new RelayCommand(obj =>
                  {
                      catalog.AddNewID(ID, SelectedSameIDProduct);
                      if (catalog.DeleteSameIDExportImportProduct(SelectedSameIDProduct,SameIDProductsList, ExistingIDList))
                      {
                          if (catalog.RealsameIDExportImportProducts.Count == 0)
                          {
                              if (catalog.IsImportProduct==false)
                              {
                                  catalog.SerializeExportProducts();
                              }
                              else
                              {
                                  catalog.AddImportProducts();
                              }
                              Root.NextWindow("CatalogVM");

                          }  
                      }
                      else
                      {
                          MessageBoxResult WrongID = MessageBox.Show("Wrong ID");
                      }
                  }));
            }
        }

    }
}
