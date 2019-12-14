using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreCatalogWPF.Models.Product;

namespace StoreCatalogWPF.Models.Product.TypeProduct
{
    [Serializable]
    class AudioEquipment:GeneralProduct
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

        private int capacity;
        public int Capasity
        {
            set
            {
                capacity = value;
                OnPropertyChanged("Capasity");
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
                OnPropertyChanged("UpperFrequencyRange");
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
                OnPropertyChanged("DownFrequencyRange");
            }
            get
            {
                return downFrequencyRange;
            }
        }

    }
}
