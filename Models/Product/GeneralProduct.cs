using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace StoreCatalogWPF.Models.Product
{
    [Serializable]
    class GeneralProduct:ICloneable,INotifyPropertyChanged
    {
        private string producer;
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

        private string title;
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

        private double price;
        public double Price
        {
            set
            {
                price = value;
                OnPropertyChanged("Prise");
            }
            get
            {
                return price;
            }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
            get
            {
                return phoneNumber;
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
