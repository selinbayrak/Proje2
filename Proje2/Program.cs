using System.Net.NetworkInformation;

namespace Proje2

{
    internal class program


    {
        internal static int HAZNEKOTA;
        internal static int FULL = 8;
        public static int Mus_Secim, Mus_Secim2;
        public static int Mus_Para = -1;
        static int eklenen_para;

        public static Int32 Main()
        {

            OtomatUrunler.UrunListele();

            Console.WriteLine("Lutfen bir urun secin: 0-1-2-3-4-5-6-7. Admin Paneli icin 8'a Basin.");
            int Mus_Secim = Convert.ToInt32(Console.ReadLine());

           
            if (Mus_Secim == 0 || Mus_Secim == 1 || Mus_Secim == 2 || Mus_Secim == 3 || Mus_Secim == 4 || Mus_Secim == 5 || Mus_Secim == 6 || Mus_Secim == 7)
            {
                
                if (OtomatUrunler.UrunAdetKontrol(Mus_Secim)==0)
                {
                    Console.WriteLine("Lutfen Paranizi Otomata Birakin.");
                    int Mus_Para = Convert.ToInt32(Console.ReadLine()); 

                    OtomatUrunler.ParaKontrol(Mus_Secim, Mus_Para);
                }
               
            }

            else if (Mus_Secim == 8)
            {
                Admin.AdminPanel();
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
                Console.WriteLine("Kacıncı Hazneye Yeni Urunu Eklemek istediginizi Secin.: 0-1-2-3-4-5-6-7");
                int Hazne = Convert.ToInt32(Console.ReadLine());

                if (OtomatUrunler.UrunAdetKontrol(Hazne) == 1)

                {
                    Console.WriteLine("Yeni Urunleri Hazneye Yerlestirin");
                }

                else if (OtomatUrunler.UrunAdetKontrol(Hazne) == 0)

                {
                    Console.WriteLine("Bu hazne farklı bir urunle dolu oldugundan yeni ürün ekleyemezsiniz.");
                }
            }

            if (Admin_Secim == 1)
            {
                Console.WriteLine("Kacıncı Hazneye Urun Eklemek istediginizi Secin.: 0-1-2-3-4-5-6-7");
                int Hazne = Convert.ToInt32(Console.ReadLine());

                if (OtomatUrunler.UrunAdetKontrol(Hazne) == 0)

                {
                    Console.WriteLine("Yeni Urunleri Hazneye Ekleyin.");
                }

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
            string[] urunler = new string[FULL];

            urunler[0] = "fanta";
            urunler[1] = "kola";
            urunler[2] = "cikolata";
            urunler[3] = "cubuk_kraker";
            urunler[4] = "su";

            int[] fiyatlar = new int[FULL];

            fiyatlar[0] = 50;
            fiyatlar[1] = 45;
            fiyatlar[2] = 55;
            fiyatlar[3] = 30;
            fiyatlar[4] = 10;


            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(i + "." + urunler[i] + "=" + fiyatlar[i] + "TL");
            }

        }
        internal static int ParaKontrol(int secim, int para)
        {
            int[] fiyatlar = new int[FULL];

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
            int[] fiyatlar = new int[FULL];

            fiyatlar[0] = 50;
            fiyatlar[1] = 45;
            fiyatlar[2] = 55;
            fiyatlar[3] = 30;
            fiyatlar[4] = 10;

            int kalan_para = para - fiyatlar[secim];
            Console.WriteLine("Para Ustunuz: " + kalan_para + "TL Almayi Unutmayin.");

            return 0;
        }
        internal static int UrunAdetKontrol(int secim) 
        {
            
            int[] adetler = new int[FULL];

            adetler[0] = 8;
            adetler[1] = 8;
            adetler[2] = 8;
            adetler[3] = 8;
            adetler[4] = 8;

            if (0 < adetler[secim] )
            { 
                    if (secim == 0 || secim == 1 || secim == 2 || secim == 3 || secim == 4 || secim == 5 || secim == 6 || secim == 7)

                        adetler[secim] -= 1;
                return 0;
            }

           else if (adetler[secim] == 0)
            {
                Console.WriteLine("Burada Urun Yoktur.");
                return 1;
            }

            else
                return 0;

        }
        
     }
}
