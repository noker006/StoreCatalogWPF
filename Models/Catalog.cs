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

namespace StoreCatalogWPF.Models
{
    class Catalog
    {
       public Catalog()
        {
            Products = new List<GeneralProduct>();
            StartDeserialization();
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
            using (FileStream stream = File.Create("Catalog.bin"))
            {
                formatter.Serialize(stream,Products);
            }
        }

        private void StartDeserialization()
        {
            var formatter = new BinaryFormatter();
            using (FileStream stream = File.OpenRead("Catalog.bin"))
            {
                Products = (List<GeneralProduct>)formatter.Deserialize(stream);
            }
        }
        private double minPrice;
        private double maxPrice;

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

        public string RequiredProducer;

        public List<AudioEquipment> AllSubtypesAudioEquipment;
        public List<Phone_Phonegadget> AllSubtypesPhone_Phonegadget;
        public List<PhotoVideoEquipment> AllSubtypesPhotoVideoEquipment;
        private List<GeneralProduct> Products;

        
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



    }
}
