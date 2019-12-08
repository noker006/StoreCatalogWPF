﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }
            get
            {
                return resolution;
            }
        }


    }
}
