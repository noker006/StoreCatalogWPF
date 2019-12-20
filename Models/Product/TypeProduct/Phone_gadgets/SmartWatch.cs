using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreCatalogWPF.Models.Product.TypeProduct;


namespace StoreCatalogWPF.Models.Product.TypeProduct.Phone_gadgets
{
    [Serializable]
    class SmartWatch:Phone_Phonegadget
    {
        private int capacityMusicPlayer;
        public int CapacityMusicPlayer
        {
            set
            {
                capacityMusicPlayer = value;
            }
            get
            {
                return capacityMusicPlayer;
            }
        }

        private string typeSmartWatch = "";

        public string TypeSmartWatch
        {
            set
            {
                typeSmartWatch = value;
                OnPropertyChanged("typeSmartWatch");
            }
            get
            {
                return typeSmartWatch;
            }
        }
    }
}
