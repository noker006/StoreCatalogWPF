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
        public int CapacityBattery
        {
            set
            {
                capacityBattery = value;
                OnPropertyChanged("CapacityBattery");
            }
            get
            {
                return capacityBattery;
            }
        }

        private bool stereoSpeakers = false;
        public bool StereoSpeakers
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
