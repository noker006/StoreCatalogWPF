using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreCatalogWPF.Models.Product.TypeProduct;

namespace StoreCatalogWPF.Models.Product.TypeProduct.PhotoVideoEquipments
{
    [Serializable]
    class VideoCamera:PhotoVideoEquipment
    {
        private string videoCompressionFormat = "";

        public string VideoCompressionFormat
        {
            set
            {
                videoCompressionFormat = value;
                OnPropertyChanged("videoCompressionFormat");
            }
            get
            {
                return videoCompressionFormat;
            }
        }

        private bool is3D;

        public bool Is3D
        {
            set
            {
                is3D = value;
                OnPropertyChanged("Is3D");
            }
            get
            {
                return is3D;
            }
        }
        
    }
}
