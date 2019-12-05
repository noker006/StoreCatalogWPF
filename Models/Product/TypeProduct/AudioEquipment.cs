using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreCatalogWPF.Models.Product;

namespace StoreCatalogWPF.Models.Product.TypeProduct
{
    class AudioEquipment:Product
    {

        private int capacity;
        public int Capasity
        {
            set
            {
                capacity = value;
            }
            get
            {
                return capacity;
            }
        }

        private int upperFrequencyRange;

        public int UpperFrequencyRange
        {
            set
            {
                upperFrequencyRange = value;
            }
            get
            {
                return upperFrequencyRange;
            }
        }

        private int downFrequencyRange;

        public int DownFrequencyRange
        {
            set
            {
                downFrequencyRange = value;
            }
            get
            {
                return downFrequencyRange;
            }
        }

    }
}
