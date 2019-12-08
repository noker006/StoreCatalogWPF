using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreCatalogWPF.Models.Product;

namespace StoreCatalogWPF.Comparers
{
    class PriceComparer:IComparer<GeneralProduct>
    {
        public int Compare(GeneralProduct i, GeneralProduct j)
        {
            return i.Price.CompareTo(j.Price);
        }
    }
}
