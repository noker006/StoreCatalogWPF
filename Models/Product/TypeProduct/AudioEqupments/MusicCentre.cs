using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreCatalogWPF.Models.Product.TypeProduct;

namespace StoreCatalogWPF.Models.Product.TypeProduct.AudioEqupments
{
    class MusicCentre:AudioEquipment
    {
        private int amountEqualizerMode;

        public int AmountEqualizerMode
        {
            set
            {
                amountEqualizerMode = value;
                OnPropertyChanged();
            }
            get
            {
                return amountEqualizerMode;
            }
        }
    }
}
