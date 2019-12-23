using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreCatalogWPF.Models.Product.TypeProduct;

namespace StoreCatalogWPF.Models.Product.TypeProduct.Phone_gadgets
{
    [Serializable]
    class Phone:Phone_Phonegadget
    {
        private string processor = "";
        public string Processor
        {
            set
            {
                processor = value;
                OnPropertyChanged("Processor");
            }
            get
            {
                return processor;
            }
        }

        private int cpuClock;
        public int CpuClock
        {
            set
            {
                cpuClock = value;
                OnPropertyChanged("CpuClock");
            }
            get
            {
                return cpuClock;
            }
        }

    }
}
