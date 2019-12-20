using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace StoreCatalogWPF.Models.Product.TypeProduct
{
    [Serializable]
    class Phone_Phonegadget:GeneralProduct
    {
        private string subtypeName;

        public string SubtypeName
        {
            set
            {
                subtypeName = value;
                OnPropertyChanged("SubtypeName");
            }
            get
            {
                return subtypeName;
            }
        }

        private string oS="";
        public string OS
        {
            set
            {
                oS = value;
                OnPropertyChanged("OS");
            }
            get
            {
                return oS;
            }
        }

        private string batteryCapacity = "";
        public string BatteryCapacity
        {
            set
            {
                batteryCapacity = value;
                OnPropertyChanged("BatteryCapacity");
            }
            get
            {
                return batteryCapacity;
            }
        }



    }
}
