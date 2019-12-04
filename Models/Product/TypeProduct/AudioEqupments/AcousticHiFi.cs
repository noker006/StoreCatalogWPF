using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreCatalogWPF.Models.Product.TypeProduct;


namespace StoreCatalogWPF.Models.Product.TypeProduct.AudioEqupments
{
    class AcousticHiFi:AudioEquipment
    {
        private int sensitivity;
        public int Sensitivity
        {
            set
            {
                sensitivity = value;
                OnPropertyChanged();
            }
            get
            {
                return sensitivity;
            }
        }
    }
}
