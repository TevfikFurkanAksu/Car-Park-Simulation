using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otopark_Simulation
{
    class Program
    {
        static int ucretHesaplama(int sure_park)
        {
            int ucret = 0;

            if(sure_park >= 0 && sure_park <= 180)
            {
                if (sure_park/60 ==0)
                {
                    ucret = 3;
                }
                else
                {
                    ucret = (sure_park / 60) * 3;
                }
            }

            else if (sure_park > 180 && sure_park <= 360)
            {
                int yeni_sure_park = sure_park - 180;
                ucret = 9 + ((yeni_sure_park/60)+1)*2;
            }

            else if (sure_park >360)
            {
                int toplamKaçUcSaat = (sure_park-360)/180;
                ucret = 15 + (toplamKaçUcSaat+1)*5;
            }
            else
            {
                Console.WriteLine("Bir Hata Oluştu");
            }
            return ucret;
        }

      
        //park süresinin dakika cinsinden hesaplandığı fonksiyon
        static int ParkSuresiHesaplama(int girisSaati, int cikisSaati, int girisDakikasi, int cikisDakikasi)
        {
            int parkSuresi = 0;
            int toplamParkDakikası = 0;//park süresinin dakikasi
            int toplamParkSaati = 0;// park süresinin saati
            if (cikisSaati>girisSaati)//cıkıs saatinin giriş saatinden büyük olma durumu
            {
                if (girisDakikasi > cikisDakikasi)// giriş dakikası çıkışdan büyük ise yapılacak işlem
                {
                    toplamParkDakikası = (60 + cikisDakikasi) - girisDakikasi;
                    toplamParkSaati = (cikisSaati - 1) - girisSaati;
                }
                else if(girisDakikasi <= cikisDakikasi)//tam tersi olan durumda yapılacak işlem
                {
                    toplamParkDakikası = cikisDakikasi - girisDakikasi;
                    toplamParkSaati = cikisSaati - girisSaati;
                }
            }
            else if (cikisSaati == girisSaati)//giriş saati ve çıkış saatinin eşit olduğu durumda yapılam işlem
            {
                if (cikisDakikasi >= girisDakikasi)
                {
                    toplamParkDakikası = (60 + cikisDakikasi) - girisDakikasi;
                    toplamParkSaati = (cikisSaati - 1) - girisSaati;
                }
                else
                {
                    Console.WriteLine("Giriş saati çıkış satinden büyük");
                }
            }
            else//giriş saati çıkıştan büyük ise yapılan işlem
            {
                Console.WriteLine("Giriş saati çıkış satinden büyük");
            }

            parkSuresi = (toplamParkSaati * 60) + toplamParkDakikası;
            return parkSuresi;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Lütfen giriş saatini giriniz");
                int girisSaati = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Lütfen giriş dakikasını giriniz");
                int girisDakikası = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Lütfen çıkış saatini giriniz");
                int cıkısSaati = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Lütfen çıkış dakikasını giriniz");
                int cıkısDakikası = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Giriş Saati :" + girisSaati + ":" + girisDakikası);
                Console.WriteLine("Çıkış Saati :" + cıkısSaati + ":" + cıkısDakikası);

                int park_suresi = ParkSuresiHesaplama(girisSaati, cıkısSaati, girisDakikası, cıkısDakikası);
                Console.WriteLine("Park süreniz:" + park_suresi + "dakikadır");

                int ucret = ucretHesaplama(park_suresi);
                Console.WriteLine("Park ücretiniz:" + ucret + "TL'dir");

                Console.WriteLine("Devam etmek için bir tuşa basıp 'Enter'a basın");

                Console.ReadLine();
            }
           



        }
    }
}
