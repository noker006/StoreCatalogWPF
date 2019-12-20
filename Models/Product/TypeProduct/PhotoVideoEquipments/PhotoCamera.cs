using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreCatalogWPF.Models.Product.TypeProduct;

namespace StoreCatalogWPF.Models.Product.TypeProduct.PhotoVideoEquipments
{
    [Serializable]
    class PhotoCamera:PhotoVideoEquipment
    {
        private string typeOfCamera = "";
        private string opticalZoom = "";
        public string TypeOfCamera
        {
            set
            {
                typeOfCamera = value;
                OnPropertyChanged("TypeOfCamera");
            }
            get
            {
                return typeOfCamera;
            }
        }
        public string OpticalZoom
        {
            set
            {
                opticalZoom = value;
                OnPropertyChanged("OpticalZoom");
            }
            get
            {
                return opticalZoom;
            }
        }
    }
}
