using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreCatalogWPF.Models.Product.TypeProduct;

namespace StoreCatalogWPF.Models.Product.TypeProduct.PhotoVideoEquipments
{
    class PhotoCamera:PhotoVideoEquipment
    {
        private string typeOfCamera;
        public string TypeOfCamera
        {
            set
            {
                typeOfCamera = value;
                OnPropertyChanged();
            }
            get
            {
                return typeOfCamera;
            }
        }
    }
}
