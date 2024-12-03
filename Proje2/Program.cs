using System.Net.NetworkInformation;

namespace Proje2

{
    internal class program


    {

        public static int Mus_Secim = -1;
        public static int Mus_Para = -1;
        static int eklenen_para;

        public static Int32 Main()
        {
            while (Mus_Secim != -100)
            {
                OtomatUrunler.UrunListele();

                Console.WriteLine("Lutfen bir urun secin: 0-1-2-3-4. Admin Paneli icin 8'a Basin.Cikis icin -100e basin");
                int Mus_Secim = Convert.ToInt32(Console.ReadLine());

                if (Mus_Secim == 0 || Mus_Secim == 1 || Mus_Secim == 2 || Mus_Secim == 3 || Mus_Secim == 4)
                {

                    OtomatUrunler.UrunAdetKontrol(Mus_Secim, 0, 1, 0);

                    Console.WriteLine("Lutfen Paranizi Otomata Birakin.");
                    int Mus_Para = Convert.ToInt32(Console.ReadLine());

                    OtomatUrunler.ParaKontrol(Mus_Secim, Mus_Para);
                }


                else if (Mus_Secim == 8)
                {
                    Admin.AdminPanel();
                }
            }
                return 0;
        }
    }
    internal class Admin : OtomatUrunler
    {
        
        internal static int AdminPanel()

        {

            Console.WriteLine("Farklı Urun Ekle: 0");
            Console.WriteLine("Aynı Urunden Yeni Urun Ekle: 1");
            Console.WriteLine("Urun Guncelle: 2");
            Console.WriteLine("Urun Sil: 3");
            Console.WriteLine("Gun Sonu Toplam Satis Goster: 4");
            Console.WriteLine("Urunleri Listele: 5");
            Console.Write("Lutfen Seciminizi Girin:");

            int Admin_Secim = Convert.ToInt32(Console.ReadLine());


            if (Admin_Secim == 0)
            {
                Console.WriteLine("Kacıncı Hazneye Yeni Urunu Eklemek istediginizi Secin.: 0-1-2-3-4");
                int Hazne = Convert.ToInt32(Console.ReadLine());

               UrunAdetKontrol(Hazne, 1, 0, 0);           
            }

            if (Admin_Secim == 1)
            {
                Console.WriteLine("Kacıncı Hazneye Urun Eklemek istediginizi Secin.: 0-1-2-3-4");
                int Hazne = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Urunu Hazneye Ekleyin.");

                UrunAdetKontrol(Hazne, 0, 0, 1);
                                
            }
            if (Admin_Secim == 2)
            {

            }
            if (Admin_Secim == 3)
            {

            }
            if (Admin_Secim == 4)
            {


            }
            if (Admin_Secim == 5)
            {

            }
            return 0;
        }
    }
    internal class OtomatUrunler : program
    {
       
        internal static void UrunListele()
        {
            string[] urunler = new string[10];


            urunler[0] = "fanta";
            urunler[1] = "kola";
            urunler[2] = "cikolata";
            urunler[3] = "cubuk_kraker";
            urunler[4] = "su";

            int[] fiyatlar = new int[10];

            fiyatlar[0] = 50;
            fiyatlar[1] = 45;
            fiyatlar[2] = 55;
            fiyatlar[3] = 30;
            fiyatlar[4] = 10;


            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i + "." + urunler[i] + "=" + fiyatlar[i] + "TL");
            }

        }
        internal static int ParaKontrol(int secim, int para)
        {
            int[] fiyatlar = new int[10];

            fiyatlar[0] = 50;
            fiyatlar[1] = 45;
            fiyatlar[2] = 55;
            fiyatlar[3] = 30;
            fiyatlar[4] = 10;

            while (para != -1)
            {
                if (para > fiyatlar[secim])
                {
                    Console.WriteLine("Urunu Otomattan Alabilirsin. ");
                    Kalan_Para_Hesapla(secim, para);
                }

                else if (para < fiyatlar[secim])
                {
                    Console.WriteLine("Paraniz Yetersiz.Para eklemek icin: 1, Para Iade Icin: 2 Tuslayin. ");
                    int Mus_Secim2 = Convert.ToInt32(Console.ReadLine());

                    if (Mus_Secim2 == 1)
                    {
                        Console.WriteLine("Lutfen Eklediginiz Parayi Girin");
                        int eklenen_para = Convert.ToInt32(Console.ReadLine());

                        para += eklenen_para;

                        ParaKontrol(secim, para);
                    }

                    else if (Mus_Secim2 == 2)
                    {
                        Console.WriteLine($"{para}TL iade edildi.");
                    }

                }
                else
                    Console.WriteLine("Urunu Otomattan Alabilirsiniz.");
                break;
            }
            return 0;
        }


        internal static int Kalan_Para_Hesapla(int secim, int para)
        {
            int[] fiyatlar = new int[10];

            fiyatlar[0] = 50;
            fiyatlar[1] = 45;
            fiyatlar[2] = 55;
            fiyatlar[3] = 30;
            fiyatlar[4] = 10;

            int kalan_para = para - fiyatlar[secim];
            Console.WriteLine("Para Ustunuz: " + kalan_para + "TL Almayi Unutmayin.");

            return 0;
        }
        internal static int UrunAdetKontrol(int secim, int yeniurunekle, int uruncikarma, int urunekleme)
        {
 
            int[] adetler = new int[10];

            adetler[0] = 6;
            adetler[1] = 6;
            adetler[2] = 6;
            adetler[3] = 6;
            adetler[4] = 6;


            if (uruncikarma == 1)
            {
                if (0 < adetler[secim])
                {
                    adetler[secim] -= 1;
                    Console.WriteLine(adetler[secim]);

                }

                else if (adetler[secim] == 0)
                {

                    Console.WriteLine("Burada Urun Kalmamistir.");

                }
            }


            else if (urunekleme == 1) 
            {

                if (adetler[secim] != 6)
                {

                    adetler[secim] += 1;

                    Console.WriteLine("Urun hazneye eklendi.");

                }

                else if (adetler[secim] == 6 )
                {
                    Console.WriteLine("Burada kota doludur. Yeni Urun Ekleyemezsiniz.");

                } 
            }
            
            else if(yeniurunekle == 1)
            {
                adetler[secim] += 1;
                Console.WriteLine("Yeni Urun hazneye eklendi.");
            }

            return 0;
        }
    }
}