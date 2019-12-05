using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreCatalogWPF.Models.Product.TypeProduct
{
    class Phone_Phonegadget:Product
    {
        private string oS;
        public string OS
        {
            set
            {
                oS = value;
            }
            get
            {
                return oS;
            }
        }

        private string batteryCapacity;
        public string BatteryCapacity
        {
            set
            {
                batteryCapacity = value;
            }
            get
            {
                return batteryCapacity;
            }
        }

        

    }
}
