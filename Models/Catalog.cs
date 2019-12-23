using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using StoreCatalogWPF.Models.Product;
using StoreCatalogWPF.Models.Product.TypeProduct;
using StoreCatalogWPF.Models.Product.TypeProduct.PhotoVideoEquipments;
using StoreCatalogWPF.Models.Product.TypeProduct.Phone_gadgets;
using StoreCatalogWPF.Models.Product.TypeProduct.AudioEqupments;
using StoreCatalogWPF.Comparers;
using StoreCatalogWPF.RelCommand;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Microsoft.Win32;


namespace StoreCatalogWPF.Models
{
    class Catalog
    {
       public Catalog()
       {
            products = new ObservableCollection<GeneralProduct>();
            AllSubtypesAudioEquipment = new ObservableCollection<AudioEquipment>
            {
                new AcousticHiFi {SubtypeName="HiFiAcoustic"},
                new MusicCentre{SubtypeName="MusicCentre"},
                new WirelessSpeaker{SubtypeName="WirelessSpeaker"}
            };
            AllSubtypesPhone_Phonegadget = new ObservableCollection<Phone_Phonegadget>
            {
                new Phone{SubtypeName="Phone"},
                new SmartWatch{SubtypeName="SmartWatch"}
            };
            AllSubtypesPhotoVideoEquipment = new ObservableCollection<PhotoVideoEquipment>
            {
                new PhotoCamera{SubtypeName="PhotoCamera"},
                new VideoCamera{SubtypeName="VideoCamera"}
            };
            System.Windows.Application.Current.Exit += ExitSerialization;
        }

        private string PathFileOpen;
        public bool CatalogOpen = false;

        private void ExitSerialization(object sender, System.Windows.ExitEventArgs e)
        {
            var formatter = new BinaryFormatter();

            using (FileStream stream = File.Create("ExtrimSave.bin"))
            {
                formatter.Serialize(stream,Products);
            }
        }
        public void Open()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "bin files (*.bin)|*.bin|alll (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                var formatter = new BinaryFormatter();
                using (FileStream stream = File.OpenRead(openFileDialog.FileName))
                {
                    products = (ObservableCollection<GeneralProduct>)formatter.Deserialize(stream);
                }
                PathFileOpen = openFileDialog.FileName;
                CatalogOpen = true;
            }
        }
        public void SaveAs()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "bin file (*.bin)|*.bin";
              if (saveFile.ShowDialog() == true)
              {
                var formatter = new BinaryFormatter();
                using (FileStream stream = File.Create(saveFile.FileName))
                {
                    formatter.Serialize(stream, Products);
                }
              }
        }
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (FileStream stream = File.Create(PathFileOpen))
            {
                formatter.Serialize(stream,Products);
            }
        }
        public void Export()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "bin files (*.bin)|*.bin|all (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                var formatter = new BinaryFormatter();
                ExportImportPath = openFileDialog.FileName;
                using (FileStream stream = File.OpenRead(ExportImportPath))
                {
                    exportImportProducts = (ObservableCollection<GeneralProduct>)formatter.Deserialize(stream);
                }
                ExportProducts(exportImportProducts);
            }
        }
        public void Import()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "bin files (*.bin)|*.bin|alll (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                var formatter = new BinaryFormatter();
                ExportImportPath = openFileDialog.FileName;
                using (FileStream stream = File.OpenRead(ExportImportPath))
                {
                  exportImportProducts = (ObservableCollection<GeneralProduct>)formatter.Deserialize(stream);
                }
                ImportProducts(exportImportProducts);
            }
        }


        private string actualTypeSearch;
        public string ActualTypeSearch
        {
            set
            {
                actualTypeSearch = value;
            }
            get
            {
                return actualTypeSearch;
            }
        }
        

        public double MaxPrice;
        public double MinPrice;
        public string Producer;
        public double MaxCapasity;
        public double MinCapasity;
        public double MinBatteryCapacity;
        public double MaxBatteryCapacity;
        public double UpperFrequencyRange;
        public void GeneralSort(ObservableCollection<GeneralProduct> ActualCollectionProducts)
        {
            for (int i = 0; i < ActualCollectionProducts.Count; i++)
            {
                if ((MaxPrice > 0 && MinPrice >= 0) && (ActualCollectionProducts[i].Price > MaxPrice || ActualCollectionProducts[i].Price < MinPrice))
                {
                    ActualCollectionProducts.Remove(ActualCollectionProducts[i]);
                }
                if ((MaxCapasity > 0 && MinCapasity >= 0) && (((AudioEquipment)ActualCollectionProducts[i]).Capasity > MaxCapasity || ((AudioEquipment)ActualCollectionProducts[i]).Capasity < MinCapasity))
                {
                    ActualCollectionProducts.Remove(ActualCollectionProducts[i]);
                }
                if (UpperFrequencyRange == ((AudioEquipment)ActualCollectionProducts[i]).UpperFrequencyRange)
                {
                    ActualCollectionProducts.Remove(ActualCollectionProducts[i]);
                }
                if ((MaxBatteryCapacity > 0 && MinBatteryCapacity >= 0) && (((Phone)ActualCollectionProducts[i]).BatteryCapacity > MaxBatteryCapacity || ((Phone)ActualCollectionProducts[i]).BatteryCapacity < MinBatteryCapacity))
                {
                    ActualCollectionProducts.Remove(ActualCollectionProducts[i]);
                }
            }
        }
        public ObservableCollection<GeneralProduct> Products
        {
            get
            {
                return products;
            }
        }

        public ObservableCollection<GeneralProduct> CreateActualCollection(object NeededTypeList)
        {
            ObservableCollection<GeneralProduct> RequiredProducts = new ObservableCollection<GeneralProduct>();
            for (int i = 0; i < Products.Count; i++)
            {
                if (NeededTypeList.GetType() == Products[i].GetType())
                {
                    RequiredProducts.Add(Products[i]);
                }
            }
            return RequiredProducts;
        }
        public void CreateRealCollection(ObservableCollection<GeneralProduct> ActualCollection)
        {
           realListProducts=CloningRealListProducts(ActualCollection);
        }
        private ObservableCollection<GeneralProduct> CloningRealListProducts(ObservableCollection<GeneralProduct> RealListProducts)
        {
            ObservableCollection<GeneralProduct> CloneRealListProducts=new ObservableCollection<GeneralProduct>();
            for (int i = 0; i < RealListProducts.Count; i++)
            {
                CloneRealListProducts.Add((GeneralProduct)RealListProducts[i].Clone());
            }
            return CloneRealListProducts;
        }

        public ObservableCollection<AudioEquipment> AllSubtypesAudioEquipment;
        public ObservableCollection<Phone_Phonegadget> AllSubtypesPhone_Phonegadget;
        public ObservableCollection<PhotoVideoEquipment> AllSubtypesPhotoVideoEquipment;

        private ObservableCollection<GeneralProduct> products;
        private ObservableCollection<GeneralProduct> realListProducts;
        private List<GeneralProduct> ClonerealListProducts = new List<GeneralProduct>();
        private AudioEquipment audioEquipment;
        private Phone_Phonegadget phone_Phonegadget;
        private PhotoCamera photoCamera;
        private GeneralProduct actualSelectedType;//для обновлений
        public GeneralProduct ActualSelectedType
        {
            set
            {
                actualSelectedType = value;
            }
            get => actualSelectedType;
        }

        public List<string> CreateProducerList(GeneralProduct NeededTypeList)
        {
            List<string> producers = new List<string>();
            for (int i = 0; i < products.Count; i++)
            {   if (NeededTypeList.GetType() == products[i].GetType())
                {
                    producers.Add(products[i].Producer);
                }
            }
            HashSet<string> Produsers = new HashSet<string>(producers);
            return new List<string>(Produsers);
        }
        public List<int> CreateUpperFrequencyRangeList(GeneralProduct NeededTypeList)
        {
            List<int>upperFrequencyRanges = new List<int>();
            for (int i = 0; i < products.Count; i++)
            {
                if (NeededTypeList.GetType() == products[i].GetType())
                {
                    upperFrequencyRanges.Add(((AudioEquipment)products[i]).UpperFrequencyRange);
                }
            }
            HashSet<int> UpperFrequencyRanges = new HashSet<int>(upperFrequencyRanges);
            return new List<int>(UpperFrequencyRanges);
       }
        public void DeleteProduct(GeneralProduct DeletedProduct,ObservableCollection<GeneralProduct> ActualCollectionProducts)    
        {
            ActualCollectionProducts.Remove(DeletedProduct);
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i] == DeletedProduct)
                {
                    if (realListProducts[i].ID == DeletedProduct.ID)
                    {
                        realListProducts.Remove(realListProducts[i]);
                    }
                    Products.Remove(Products[i]);
                    i--;
                }
            }
        }


        public ObservableCollection<GeneralProduct> Search(string EnterString)
        {
                switch (actualTypeSearch)
                {
                    case "Title":
                        {
                            return TitleSearch(EnterString);
                        }
                    case "ID":
                        {
                            return IDSearch(EnterString);
                        }
                    case "Producer":
                        {
                            return ProducerSearch(EnterString);
                        }
                    default:
                        break;
                }
                return realListProducts;
        }
        private ObservableCollection<GeneralProduct> TitleSearch(string Titlestring)
        {
            ObservableCollection<GeneralProduct> CloneRealListProducts = CloningRealListProducts(realListProducts);
            for (int i = 0; i < CloneRealListProducts.Count; i++)
            {
                if (CloneRealListProducts[i].Title.Contains(Titlestring)==false)
                {
                    CloneRealListProducts.Remove(CloneRealListProducts[i]);
                    i--;
                }
            }
            return CloneRealListProducts;
        }
        public ObservableCollection<GeneralProduct> IDSearch(string Titlestring)//поиск для idExeption
        {
            if (SameId_DifferentProduct)
            {
                ObservableCollection<GeneralProduct> CloneRealListProducts = RealExistingIDList;
                for (int i = 0; i < CloneRealListProducts.Count; i++)
                {
                    if (!CloneRealListProducts[i].ID.ToString().Contains(Titlestring))
                    {
                        CloneRealListProducts.Remove(CloneRealListProducts[i]);
                        i--;
                    }
                }
                return CloneRealListProducts;
            }
            else
            {
                ObservableCollection<GeneralProduct> CloneRealListProducts = CloningRealListProducts(realListProducts);
                for (int i = 0; i < CloneRealListProducts.Count; i++)
                {
                    if (!CloneRealListProducts[i].ID.ToString().Contains(Titlestring))
                    {
                        CloneRealListProducts.Remove(CloneRealListProducts[i]);
                        i--;
                    }
                }
                return CloneRealListProducts;
            }
        }
        private ObservableCollection<GeneralProduct> ProducerSearch(string Titlestring)
        {
            ObservableCollection<GeneralProduct> CloneRealListProducts = CloningRealListProducts(realListProducts);
            for (int i = 0; i < CloneRealListProducts.Count; i++)
            {
                if (CloneRealListProducts[i].Producer.Contains(Titlestring)==false)
                {
                    CloneRealListProducts.Remove(CloneRealListProducts[i]);
                    i--;
                }
            }
            return CloneRealListProducts;
        }

        //IDExeption
        public bool SameId_DifferentProduct=false;
        public bool IsImportProduct = false;
        private string ExportImportPath;

        private ObservableCollection<GeneralProduct> exportImportProducts=new ObservableCollection<GeneralProduct>();
        private ObservableCollection<GeneralProduct> realexistingIDList;
        private ObservableCollection<GeneralProduct> realsameIDExportImportProducts;
        private ObservableCollection<GeneralProduct> exportroducts=new ObservableCollection<GeneralProduct>();

        public ObservableCollection<GeneralProduct> ExportImportProducts
        {
            get
            {
                return exportImportProducts;
            }
        }
        public ObservableCollection<GeneralProduct> RealExistingIDList
        {
            get => realexistingIDList;
        }
        public ObservableCollection<GeneralProduct> RealsameIDExportImportProducts
        {
            get => realsameIDExportImportProducts;
        }
        public ObservableCollection<GeneralProduct> CreateExistingIDList() //List не инт тк пользуюсь Search для Обектов по ID
        {
            realexistingIDList = new ObservableCollection<GeneralProduct>();
            for (int i = 0; i < exportImportProducts.Count; i++)
            {
                if (exportImportProducts[i].ID != 0)
                {
                    realexistingIDList.Add(new GeneralProduct { ID = exportImportProducts[i].ID });
                }
            }
            if (IsImportProduct == true)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    realexistingIDList.Add(new GeneralProduct { ID = products[i].ID });
                }
            }
            return realexistingIDList;
        }
        public ObservableCollection<GeneralProduct> CreateSameIDProductsList()
        {
            realsameIDExportImportProducts = new ObservableCollection<GeneralProduct>();
            if (IsImportProduct)
            {
                for (int i = 0; i < exportImportProducts.Count; i++)
                {
                    if (exportImportProducts[i].ID == 0)
                    {
                        realsameIDExportImportProducts.Add(exportImportProducts[i]);
                    }
                }
                return realsameIDExportImportProducts;
            }
            else
            {
                for (int i = 0; i < exportroducts.Count; i++)
                {
                    if (exportroducts[i].ID == 0)
                    {
                        realsameIDExportImportProducts.Add(exportroducts[i]);
                    }
                }
                return realsameIDExportImportProducts;
            }
        }
        private void ImportProducts(ObservableCollection<GeneralProduct> exportImportProducts)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                for (int j = 0; j < exportImportProducts.Count; j++)
                {
                    if (exportImportProducts[j].ID == Products[i].ID||(exportImportProducts[j].Title.ToLower() == Products[i].Title.ToLower() && exportImportProducts[j].Producer.ToLower() == Products[i].Producer.ToLower()))
                    {
                        if (exportImportProducts[j].Title.ToLower() == Products[i].Title.ToLower() && exportImportProducts[j].Producer.ToLower() == Products[i].Producer.ToLower())
                        {
                            Products[i].AmountProduct += exportImportProducts[j].AmountProduct;
                            exportImportProducts.Remove(exportImportProducts[j]);
                            j--;
                        }
                        else
                        {
                            exportImportProducts[j].ID = 0;
                            SameId_DifferentProduct = true;
                            IsImportProduct = true;
                        }
                    }
                }
            }
            if (SameId_DifferentProduct == false)
            {
                AddImportProducts();
            }
        }
        private void ExportProducts(ObservableCollection<GeneralProduct> exportImportProducts)//Валидация ID!=0 !!!ExportProducts = new ObservableCollection<GeneralProduct>();
        {
            bool NeeedRecordtoExportProducts = true;
            for (int i = 0; i < Products.Count; i++)
            {
                for (int j = 0; j < exportImportProducts.Count; j++)
                {
                    if (exportImportProducts[j].ID == Products[i].ID || (exportImportProducts[j].Title.ToLower() == Products[i].Title.ToLower() && exportImportProducts[j].Producer.ToLower() == Products[i].Producer.ToLower()))
                    {

                        if (exportImportProducts[j].Title.ToLower() == Products[i].Title.ToLower() && exportImportProducts[j].Producer.ToLower() == Products[i].Producer.ToLower())
                        {
                            exportImportProducts[j].AmountProduct += Products[i].AmountProduct;
                            exportroducts.Add(exportImportProducts[j]);
                            NeeedRecordtoExportProducts = false;
                        }
                        else
                        {
                            GeneralProduct BufferProduct = new GeneralProduct();
                            BufferProduct = (GeneralProduct)Products[i].Clone();
                            BufferProduct.ID = 0;
                            exportroducts.Add(BufferProduct);
                            exportroducts.Add(exportImportProducts[j]);//общий лист со всеми обектами ,даже c повторившимися(их ID равен 0) ID 
                            NeeedRecordtoExportProducts = false;
                            SameId_DifferentProduct = true;
                        }
                    }
                }
                    if (NeeedRecordtoExportProducts == true)
                    {
                       exportroducts.Add(Products[i]);
                    }
                    NeeedRecordtoExportProducts = true;
            }
            if (SameId_DifferentProduct == false)
            {
                SerializeExportProducts();
            }
           
        }
        public void AddImportProducts()
        {
                for (int j = 0; j < exportImportProducts.Count; j++)
                {
                    products.Add(exportImportProducts[j]);
                }
            exportImportProducts = new ObservableCollection<GeneralProduct>();
            IsImportProduct = false;
        }
        public void SerializeExportProducts()
        {
            var formatter = new BinaryFormatter();
            using (FileStream stream = File.Create(ExportImportPath))
            {
                formatter.Serialize(stream, exportroducts);
            }
            SameId_DifferentProduct = false;
            exportroducts = new ObservableCollection<GeneralProduct>();
            exportImportProducts = new ObservableCollection<GeneralProduct>();
        }
        public bool DeleteSameIDExportImportProduct(GeneralProduct SameIDExportImportProduct,ObservableCollection<GeneralProduct> SameIDProductsList)
        {
            bool ExistingID = false;
                for (int i = 0; i < realexistingIDList.Count; i++)
                {
                    if (realexistingIDList[i].ID == SameIDExportImportProduct.ID && SameIDExportImportProduct.ID != 0)
                    {
                        ExistingID = true;
                    }
                }
            if (ExistingID == false)
            {
                if (IsImportProduct==false)
                {
                    SameIDProductsList.Remove(SameIDExportImportProduct);
                    return true;
                }
                else
                {
                    for (int i = 0; i < products.Count; i++)
                    {
                        if (products[i].ID== SameIDExportImportProduct.ID)
                        {
                            return false;
                        }
                    }
                    SameIDProductsList.Remove(SameIDExportImportProduct);
                    return true;
                }
            }
            return false;
        }
        public void AddNewID(int ID,GeneralProduct ExportImportProduct)
        {
            ExportImportProduct.ID = ID;
        }


        //AddProduct
        public void AddProduct(GeneralProduct product)
        {
            Products.Add(product);
        }
        public GeneralProduct CreateNewObject(GeneralProduct TypeProduct)
        {
            Type type = TypeProduct.GetType();
            switch (type.Name.ToString())
            {
                case "AcousticHiFi":
                    {
                        return new AcousticHiFi();
                    }
                case "MusicCentre":
                    {
                        return new MusicCentre();
                    }
                case "Radio":
                    {
                        return new WirelessSpeaker();
                    }
                case "Phone":
                    {
                        return new Phone();
                    }
                case "SmartWatch":
                    {
                        return new SmartWatch();
                    }
                case "PhotoCamera":
                    {
                        return new PhotoCamera();
                    }
                case "VideoCamera":
                    {
                        return new VideoCamera();
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
