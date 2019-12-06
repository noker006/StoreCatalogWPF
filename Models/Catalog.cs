using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using StoreCatalogWPF.Models.Product;
using StoreCatalogWPF.Models.Product.TypeProduct;
using StoreCatalogWPF.Models.Product.TypeProduct.PhotoVideoEquipments;
using StoreCatalogWPF.Models.Product.TypeProduct.Phone_gadgets;
using StoreCatalogWPF.Models.Product.TypeProduct.AudioEqupments;

namespace StoreCatalogWPF.Models
{
    class Catalog
    {
       public Catalog()
        {
            AcousticHiFis = new ObservableCollection<AcousticHiFi>
            {
                new AcousticHiFi{Title="TUrboAcoustic", Price=10,Capasity=30, Producer="Sven",UpperFrequencyRange=32,DownFrequencyRange=43},
                new AcousticHiFi{Title="GiperAcoustic", Price=20,Capasity=42, Producer="Sumsung",UpperFrequencyRange=32,DownFrequencyRange=43},
                new AcousticHiFi{Title="GiperAcoustic", Price=30,Capasity=52, Producer="Lg",UpperFrequencyRange=32,DownFrequencyRange=43},

            };
            PhotoCameras = new ObservableCollection<PhotoCamera>
            {
                new PhotoCamera{ Title="TUrboCamera", Price=20,Producer="Nikon", Resolution="12X234", TypeOfCamera="mirror" },
                new PhotoCamera{Title="GiperCamera", Price=30, Producer="ZarYA", Resolution="12X234", TypeOfCamera="mirror" }
            };


        }

       public AudioEquipment Audio = new AudioEquipment();
       public PhotoVideoEquipment PhotoVideo = new PhotoVideoEquipment();
       public Phone_Phonegadget Phone_Gadget = new Phone_Phonegadget();

       public AcousticHiFi acoustic = new AcousticHiFi();
       public MusicCentre musicCentre = new MusicCentre();
       public Radio radio = new Radio();

       public Phone phone = new Phone();
       public SmartWatch smartWatch = new SmartWatch();

       public PhotoCamera photoCamera = new PhotoCamera();
       public VideoCamera VideoCamera = new VideoCamera();


       public ObservableCollection<AcousticHiFi> AcousticHiFis = new ObservableCollection<AcousticHiFi>();
       public ObservableCollection<MusicCentre> MusicCentres = new ObservableCollection<MusicCentre>();
       public ObservableCollection<Radio> Radios = new ObservableCollection<Radio>();

        public ObservableCollection<Phone> Phones = new ObservableCollection<Phone>();
        public ObservableCollection<SmartWatch> SmartWatches = new ObservableCollection<SmartWatch>();

        public ObservableCollection<PhotoCamera> PhotoCameras = new ObservableCollection<PhotoCamera>();
        public ObservableCollection<VideoCamera> videoCameras = new ObservableCollection<VideoCamera>();



        
    }
}
