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
        private bool synchronization;

        public bool Synchronization
        {
            set
            {
                synchronization = value;
                OnPropertyChanged("Synchronization");
            }
            get
            {
                return synchronization;
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
