using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreCatalogWPF.ViewModels.GeneralVMs;
using StoreCatalogWPF.Models.Product;
using StoreCatalogWPF.RelCommand;
using System.Windows;

namespace StoreCatalogWPF.ViewModels
{
    class IDExeptionVM:BasicVM
    {
        public IDExeptionVM(string name, VMManager root):base(name, root)
        {
            SameIDProductsList = catalog.CreateSameIDProductsList();
            ExistingIDList = catalog.CreateExistingIDList();
        }

       private List<GeneralProduct> sameIDProductsList;
       private List<GeneralProduct> existingIDList;//хранятся только ID
        public List<GeneralProduct> SameIDProductsList
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
        public List<GeneralProduct> ExistingIDList
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
                ExistingIDList = catalog.IDSearch(catalog.RealExistingIDList,Convert.ToString(ID));
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
                      if (catalog.DeleteSameIDExportImportProduct(SelectedSameIDProduct))
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
                          SameIDProductsList =new List<GeneralProduct>( catalog.RealsameIDExportImportProducts);
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
