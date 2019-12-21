using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreCatalogWPF.Models.Product.TypeProduct;
using StoreCatalogWPF.RelCommand;


namespace StoreCatalogWPF.Models.Product.TypeProduct.AudioEqupments
{
    [Serializable]
    class AcousticHiFi:AudioEquipment
    {
        private int sensitivity;
        public int Sensitivity
        {
            set
            {
                sensitivity = value;
                OnPropertyChanged("Sensitivity");
            }
            get
            {
                return sensitivity;
            }
        }

        private int totalMaximumPower;
        public int TotalMaximumPower
        {
            set
            {
                totalMaximumPower = value;
                OnPropertyChanged("TotalMaximumPower");
            }
            get
            {
                return totalMaximumPower;
            }
        }

    }
}
