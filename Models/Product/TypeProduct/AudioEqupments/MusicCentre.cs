using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreCatalogWPF.Models.Product.TypeProduct;

namespace StoreCatalogWPF.Models.Product.TypeProduct.AudioEqupments
{
    [Serializable]
    class MusicCentre:AudioEquipment
    {
        private int amountEqualizerMode;
        public int AmountEqualizerMode
        {
            set
            {
                amountEqualizerMode = value;
                OnPropertyChanged("AmountEqualizerMode");
            }
            get
            {
                return amountEqualizerMode;
            }
        }

        private double wooferDiameter;
        public double WooferDiameter
        {
            set
            {
                wooferDiameter = value;
                OnPropertyChanged("WooferDiameter");
            }
            get
            {
                return wooferDiameter;
            }
        }

        private double tweeterDiameter;
        public double TweeterDiametr
        {
            set
            {
                tweeterDiameter = value;
                OnPropertyChanged("TweeterDiametr");
            }
            get
            {
                return tweeterDiameter;
            }
        }
    }
}
