using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using StoreCatalogWPF.Models.Product.TypeProduct;

namespace StoreCatalogWPF.Models.Product
{
    [Serializable]
    class GeneralProduct:ICloneable,INotifyPropertyChanged
    {
        private string producer="";
        private string title="";
        private double price;
        private int amountProduct;
        private int iD;


        public string Producer
        {
            set
            {
                producer = value;
                OnPropertyChanged("Producer");
            }
            get
            {
                return producer;
            }
        }

        public string Title
        {
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
            get
            {
                return title;
            }
        }

        public double Price
        {
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
            get
            {
                return price;
            }
        }

        public int AmountProduct
        {
            set
            {
                amountProduct = value;
                OnPropertyChanged("AmountProduct");
            }
            get
            {
                return amountProduct;
            }
        }

        public int ID
        {
            set
            {
                iD = value;
                OnPropertyChanged("ID");
            }
            get
            {
                return iD;
            }
        }

        public virtual object  Clone()
        {
           return MemberwiseClone();
        }

        [field: NonSerialized]

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
