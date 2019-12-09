﻿using System;
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

namespace StoreCatalogWPF.Models
{
    class Catalog
    {
       public Catalog()
        {
            allProducts = new List<GeneralProduct>
            {
                new AcousticHiFi{Title="TUrboAcoustic", Price=15,Capasity=30, Producer="Sven",UpperFrequencyRange=1000,DownFrequencyRange=43,Sensitivity=123},
                new AcousticHiFi{Title="TUrboAcoustic", Price=10,Capasity=30, Producer="Sven",UpperFrequencyRange=1000,DownFrequencyRange=43,Sensitivity=123},
                new AcousticHiFi{Title="GiperAcoustic", Price=20,Capasity=42, Producer="Sumsung",UpperFrequencyRange=1000,DownFrequencyRange=43},
                new PhotoCamera{ Title="TUrboCamera", Price=20,Producer="Nikon", Resolution="12X234", TypeOfCamera="mirror" },
                new PhotoCamera{Title="GiperCamera", Price=30, Producer="ZarYA", Resolution="12X234", TypeOfCamera="mirror" }

            };
            AllSubtypesAudioEquipment = new List<AudioEquipment>
            {
                new AcousticHiFi {SubtypeName="HiFiAcoustic"},
                new MusicCentre{SubtypeName="MusicCentre"},
                new Radio{SubtypeName="Radio"}
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
            System.Windows.Application.Current.Exit += Current_Exit;
        }

        private void Current_Exit(object sender, System.Windows.ExitEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public GeneralProduct generalProduct;

        private double minPrice;

        public double MinPrice
        {
            set
            {
                minPrice = value;
            }
            get => minPrice;
        }

        private double maxPrice;

        public double MaxPrice
        {
            set
            {
                maxPrice = value;
            }
            get => maxPrice;
        }

        public List<AudioEquipment> AllSubtypesAudioEquipment;
        public List<Phone_Phonegadget> AllSubtypesPhone_Phonegadget;
        public List<PhotoVideoEquipment> AllSubtypesPhotoVideoEquipment;

        public List<GeneralProduct> allProducts = new List<GeneralProduct>();

        public List<object> NewProduct;

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
            for (int i = 0; i < allProducts.Count; i++)
            {
                if (NeededTypeList.GetType() == allProducts[i].GetType())
                {
                    RequiredProducts.Add(allProducts[i]);
                }
            }
            return RequiredProducts;
       }
        public List<GeneralProduct> PriceSort(List<GeneralProduct> RealListProducts)
        {
            if (maxPrice > 0 && minPrice > 0)
            {
                List<GeneralProduct> CloneRealListProducts = CloningRealListProducts(RealListProducts);
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
            return RealListProducts;
        }

        //public List<GeneralProduct> GeneralSort(List<GeneralProduct> RealListProducts)
        //{
        //    PriceSort(RealListProducts);

        //}





    }
}
