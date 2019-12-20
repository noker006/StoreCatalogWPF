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
        private int capacityBattery;
        public int CapacityBatttery
        {
            set
            {
                capacityBattery = value;
                OnPropertyChanged("BattteryCapacity");
            }
            get
            {
                return capacityBattery;
            }
        }

        private string stereoSpeakers = "";
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
