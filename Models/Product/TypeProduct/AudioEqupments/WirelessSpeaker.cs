using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreCatalogWPF.Models.Product.TypeProduct;


namespace StoreCatalogWPF.Models.Product.TypeProduct.AudioEqupments
{
    [Serializable]
    class WirelessSpeaker: AudioEquipment
    {
        private int batteryCapacity;
        public int BattteryCapacity
        {
            set
            {
                batteryCapacity = value;
                OnPropertyChanged("BattteryCapacity");
            }
            get
            {
                return batteryCapacity;
            }
        }

        private string stereoSpeakers;
        public string StereoSpeakers
        {
            set
            {
                stereoSpeakers = value;
                OnPropertyChanged("StereoSpeakers");
            }
            get
            {
                return stereoSpeakers;
            }
        }

    }
}
