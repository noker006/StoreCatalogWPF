using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace StoreCatalogWPF.Models.Product.TypeProduct
{
    class PhotoVideoEquipment:GeneralProduct
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

        private string typeMatrix;
        public string TypeMatrix
        {
            set
            {
                typeMatrix = value;
                OnPropertyChanged("TypeMatrix");
            }

            get
            {
                return typeMatrix;
            }
        }

        private string matrixSize;
        public string MatrixSize
        {
            set
            {
                matrixSize = value;
                OnPropertyChanged("MatrixSize");
            }
            get
            {
                return matrixSize;
            }
        }

        private string resolution;

        public string Resolution
        {
            set
            {
                resolution = value;
                OnPropertyChanged("Resolution");
            }
            get
            {
                return resolution;
            }
        }


    }
}
