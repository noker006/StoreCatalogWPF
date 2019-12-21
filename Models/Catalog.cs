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
            products = new List<GeneralProduct>();
            AllSubtypesAudioEquipment = new List<AudioEquipment>
            {
                new AcousticHiFi {SubtypeName="HiFiAcoustic"},
                new MusicCentre{SubtypeName="MusicCentre"},
                new WirelessSpeaker{SubtypeName="WirelessSpeaker"}
            };
            AllSubtypesPhone_Phonegadget = new List<Phone_Phonegadget>
            {
                new Phone{SubtypeName="Phone"},
                new SmartWatch{SubtypeName="SmartWatch"}
            };
            AllSubtypesPhotoVideoEquipment = new List<PhotoVideoEquipment>
            {
                new PhotoCamera{SubtypeName="PhotoCamera"},
                new VideoCamera{SubtypeName="VideoCamera"}
            };
            System.Windows.Application.Current.Exit += ExitSerialization;
        }

        private void ExitSerialization(object sender, System.Windows.ExitEventArgs e)
        {
            var formatter = new BinaryFormatter();
            using (FileStream stream = File.Create("ExtremeSave.bin"))
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
                    products = (List<GeneralProduct>)formatter.Deserialize(stream);
                }
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
                    exportImportProducts = (List<GeneralProduct>)formatter.Deserialize(stream);
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
                    exportImportProducts = (List<GeneralProduct>)formatter.Deserialize(stream);
                }
                ImportProducts(exportImportProducts);
            }
        }
        private double minPrice;
        private double maxPrice;
        private string actualTypeSearch;
        private string ExportImportPath;


        public bool SameId_DifferentProduct=false;
        public bool IsImportProduct = false;
        public bool CatalogOpen = false;

        public double MinPrice
        {
            set
            {
                minPrice = value;
            }
            get => minPrice;
        }
        public double MaxPrice
        {
            set
            {
                maxPrice = value;
            }
            get => maxPrice;
        }

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

        public string RequiredProducer;

        public List<GeneralProduct> RealListProducts
        {
            set
            {
                realListProducts = value;
            }
            get
            {
                return realListProducts;
            }
        }
        public List<GeneralProduct> Products
        {
            get
            {
                return products;
            }
        }

        public List<GeneralProduct> ExportImportProducts
        {
            get
            {
                return exportImportProducts;
            }
        }

        public List<GeneralProduct> RealExistingIDList
        {
            get => existingIDList;
        }

        public List<GeneralProduct> RealsameIDExportImportProducts
        {
            get => sameIDExportImportProducts;
        }

        public List<AudioEquipment> AllSubtypesAudioEquipment;
        public List<Phone_Phonegadget> AllSubtypesPhone_Phonegadget;
        public List<PhotoVideoEquipment> AllSubtypesPhotoVideoEquipment;
        private List<GeneralProduct> products;
        private List<GeneralProduct> exportImportProducts=new List<GeneralProduct>();
        private List<GeneralProduct> existingIDList;
        private List<GeneralProduct> sameIDExportImportProducts;
        private List<GeneralProduct> realListProducts;
        public List<string> CreateListProducer(List<GeneralProduct> products)
        {
            List<string> producers = new List<string>();
            for (int i = 0; i < products.Count; i++)
            {
                producers.Add(products[i].Producer);
            }
            for (int i = 0; i < producers.Count - 1; i++)
            {
                for (int j = 0; j < producers.Count - i - 1; j++)
                {
                    if (producers[j + 1] == producers[j])
                    {
                        producers.Remove((string)producers[j+1]);
                        j--;
                    }
                }
            }
            return producers;
        }
        private List<GeneralProduct> CloningRealListProducts(List<GeneralProduct> RealListProducts)
        {
            List<GeneralProduct> CloneRealListProducts=new List<GeneralProduct>();
            for (int i = 0; i < RealListProducts.Count; i++)
            {
                CloneRealListProducts.Add((GeneralProduct)RealListProducts[i].Clone());
            }
            return CloneRealListProducts;
        }


        public List<GeneralProduct> GetRequiredList(object NeededTypeList)
        {
            List<GeneralProduct> RequiredProducts = new List<GeneralProduct>();
            for (int i = 0; i < Products.Count; i++)
            {
                if (NeededTypeList.GetType() == Products[i].GetType())
                {
                    RequiredProducts.Add(Products[i]);
                }
            }
            return RequiredProducts;
        }
        public List<GeneralProduct> PriceSort(List<GeneralProduct> CloneRealListProducts)
        {
            if (maxPrice > 0 && minPrice > 0)
            {
                PriceComparer priceComparer = new PriceComparer();
                for (int i = 0; i < CloneRealListProducts.Count; i++)
                {
                    if (CloneRealListProducts[i].Price > maxPrice || CloneRealListProducts[i].Price < minPrice)
                    {
                        CloneRealListProducts.Remove(CloneRealListProducts[i]);
                        i--;
                    }
                }
                CloneRealListProducts.Sort(priceComparer);
                return CloneRealListProducts;
            }
            return CloneRealListProducts;
        }
        private List<GeneralProduct> ProduProducerSort(List<GeneralProduct> CloneRealListProducts)
        {
            for (int i = 0; i < CloneRealListProducts.Count; i++)
            {
                if(CloneRealListProducts[i].Producer != RequiredProducer)
                {
                    CloneRealListProducts.Remove(CloneRealListProducts[i]);
                    i--;
                }
            }
            return CloneRealListProducts;
        }
        public List<GeneralProduct> GeneralSort(List<GeneralProduct> RealListProducts)
        {
            List<GeneralProduct> CloneRealListProducts = CloningRealListProducts(RealListProducts);
            PriceSort(CloneRealListProducts);
            ProduProducerSort(CloneRealListProducts);
            return CloneRealListProducts;
        }
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
        public void DeleteProduct(GeneralProduct DeletedProduct)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i] == DeletedProduct)
                {
                    Products.Remove(Products[i]);
                    i--;
                }
            }
        }

        public List<GeneralProduct> Search(string EnterString,List<GeneralProduct> RealListProducts)
        {
                switch (actualTypeSearch)
                {
                    case "Title":
                        {
                            return TitleSearch(RealListProducts, EnterString);
                        }
                    case "ID":
                        {
                            return IDSearch(RealListProducts, EnterString);
                        }
                    case "Producer":
                        {
                            return ProducerSearch(RealListProducts, EnterString);
                        }
                    default:
                        break;
                }
                return RealListProducts;
        }

        private List<GeneralProduct> TitleSearch(List<GeneralProduct> RealListProducts, string Titlestring)
        {
            List<GeneralProduct> CloneRealListProducts = CloningRealListProducts(RealListProducts);
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

        public List<GeneralProduct> IDSearch(List<GeneralProduct> RealListProducts, string Titlestring)
        {
            List<GeneralProduct> CloneRealListProducts = CloningRealListProducts(RealListProducts);
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

        private List<GeneralProduct> ProducerSearch(List<GeneralProduct> RealListProducts, string Titlestring)
        {
            List<GeneralProduct> CloneRealListProducts = CloningRealListProducts(RealListProducts);
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


        private void ImportProducts(List<GeneralProduct> exportImportProducts)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                for (int j = 0; j < exportImportProducts.Count; j++)
                {
                    if (exportImportProducts[j].ID == Products[i].ID)
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
        private void ExportProducts(List<GeneralProduct> exportImportProducts)//Валидация ID!=0 !!!ExportProducts = new List<GeneralProduct>();
        {
            bool NeeedRecordtoExportProducts = true;
            for (int i = 0; i < Products.Count; i++)
            {
                for (int j = 0; j < exportImportProducts.Count; j++)
                {
                    if(exportImportProducts[j].ID==Products[i].ID)
                    {

                        if(exportImportProducts[j].Title.ToLower() == Products[i].Title.ToLower()&& exportImportProducts[j].Producer.ToLower() == Products[i].Producer.ToLower())
                        {
                            exportImportProducts[j].AmountProduct += Products[i].AmountProduct;
                            NeeedRecordtoExportProducts = false;
                        }
                        else
                        {
                            GeneralProduct BufferProduct = new GeneralProduct();
                            BufferProduct = (GeneralProduct)Products[i].Clone();
                            BufferProduct.ID = 0;
                            exportImportProducts.Add(BufferProduct); //общий лист со всеми обектами ,даже c повторившимися(их ID равен 0) ID 
                            NeeedRecordtoExportProducts = false;
                            SameId_DifferentProduct = true;
                        }
                    }
                }
                if (NeeedRecordtoExportProducts == true)
                {
                    exportImportProducts.Add(Products[i]);
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
 
            exportImportProducts = new List<GeneralProduct>();
            IsImportProduct = false;
        }
        public void SerializeExportProducts()
        {
            var formatter = new BinaryFormatter();
            using (FileStream stream = File.Create(ExportImportPath))
            {
                formatter.Serialize(stream, exportImportProducts);
            }
            SameId_DifferentProduct = false;
            exportImportProducts = new List<GeneralProduct>();
        }

        public List<GeneralProduct> CreateExistingIDList() //List не инт тк пользуюсь Search для Обектов по ID
        {
            existingIDList = new List<GeneralProduct>();
            for (int i = 0; i < exportImportProducts.Count; i++)
            {
                if (exportImportProducts[i].ID != 0)
                {
                    existingIDList.Add(new GeneralProduct { ID = exportImportProducts[i].ID });
                }
            }
            if (IsImportProduct == true)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    existingIDList.Add(new GeneralProduct { ID = products[i].ID });
                }
            }
            return existingIDList;
        }
        public List<GeneralProduct> CreateSameIDProductsList()
        {
            sameIDExportImportProducts = new List<GeneralProduct>();
            for (int i = 0; i < exportImportProducts.Count; i++)
            {
                if (exportImportProducts[i].ID == 0)
                {
                    sameIDExportImportProducts.Add(exportImportProducts[i]);
                }
            }
            return sameIDExportImportProducts;
        }

        public bool DeleteSameIDExportImportProduct(GeneralProduct SameIDExportImportProduct)
        {
            bool ExistingID = false;
                for (int i = 0; i < existingIDList.Count; i++)
                {
                    if (existingIDList[i].ID == SameIDExportImportProduct.ID && SameIDExportImportProduct.ID != 0)
                    {
                        ExistingID = true;
                    }
                }
            if (ExistingID == false)
            {
                if (IsImportProduct==false)
                {
                    sameIDExportImportProducts.Remove(SameIDExportImportProduct);
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
                    sameIDExportImportProducts.Remove(SameIDExportImportProduct);
                    return true;
                }
            }
            return false;
        }

        public void AddNewID(int ID,GeneralProduct ExportImportProduct)
        {
            ExportImportProduct.ID = ID;
        }
    }
}
