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
    class Product
    {
        private double price;
        public double Price
        {
            set
            {
                price = value;
                OnPropertyChanged();
            }
            get
            {
                return price;
            }
        }

        private string producer;
        public string Producer
        {
            set
            {
                producer = value;
                OnPropertyChanged();
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
                OnPropertyChanged();
            }
            get
            {
                return title;
            }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            set
            {
                phoneNumber = value;
                OnPropertyChanged();
            }
            get
            {
                return phoneNumber;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
