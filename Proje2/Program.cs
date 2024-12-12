using System.Diagnostics;
using System.Net.NetworkInformation;

namespace Proje2

{
    public class program

    {
        static int eklenen_para;

        public static Int32 Main()
        { 

            while (true)
            {
                OtomatUrunler.UrunListele();

                Console.WriteLine("Lutfen bir urun secin: 0-1-2-3-4. Admin Paneli icin 8'a Basin.Cikis icin -100e basin");
                int Mus_Secim = Convert.ToInt32(Console.ReadLine());

                if (Mus_Secim == 0 || Mus_Secim == 1 || Mus_Secim == 2 || Mus_Secim == 3 || Mus_Secim == 4)
                {                 

                    Console.WriteLine("Lutfen Paranizi Otomata Birakin.");
                    int Mus_Para = Convert.ToInt32(Console.ReadLine());

                    OtomatUrunler.ParaKontrol(Mus_Secim, Mus_Para);

                    OtomatUrunler.UrunAdetKontrol(Mus_Secim, 0, 1, 0);
                }


                else if (Mus_Secim == 8)
                {
                    Admin.AdminPanel();
                }

                else if(Mus_Secim == -100)
                {
                    break;
                }
            }
                return 0;
        }
    }
    public class Admin : OtomatUrunler
    {
        
        public static int AdminPanel()

        {

            Console.WriteLine("Hazne Bossa Yeni Urunleri Ekle: 0");
            Console.WriteLine("Aynı Urunden Hazneye Ekleme Yap: 1");
            Console.WriteLine("Urun Guncelle: 2");
            Console.WriteLine("Urun Sil: 3");
            Console.WriteLine("Gun Sonu Toplam Satis Goster: 4");
            Console.WriteLine("Urunleri Listele: 5");
            Console.Write("Lutfen Seciminizi Girin:");

            int Admin_Secim = Convert.ToInt32(Console.ReadLine());


            if (Admin_Secim == 0)
            {
                Console.WriteLine("Kacıncı Hazneye Yeni Urunleri Eklemek istediginizi Secin.: 0-1-2-3-4");
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
                Console.WriteLine("Hazne Secin: 0-1-2-3-4");
                int guncellenecekIndex = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ürün Adi:");
                string YeniUrun = Console.ReadLine();
                
                Console.WriteLine("Ürün Fiyati:");
                int YeniFiyat = Convert.ToInt32(Console.ReadLine());

                urunler[guncellenecekIndex] = YeniUrun ?? "ürün yok"; // ?? null ise "ürün yok" eklenecek
                fiyatlar[guncellenecekIndex] = YeniFiyat;
                
                Console.WriteLine("Ürün Güncellendi");
            }
            if (Admin_Secim == 3)
            {
                Console.WriteLine("Silinecek Ürün Haznesi Nedir: 0-1-2-3-4");
                int silinecekIndex = Convert.ToInt32(Console.ReadLine());

                Array.Clear(urunler, silinecekIndex, 1);
                Array.Clear(fiyatlar, silinecekIndex, 1);
                Console.WriteLine("Ürün Silindi.");

            }
            if (Admin_Secim == 4)
            {
                Console.WriteLine(satislar.Length + "adet ürün satildi");
                Console.WriteLine("Toplamda " + toplamsatis + "TL satis yapildi");

            }
            if (Admin_Secim == 5)
            {
                UrunListele();
            }
            return 0;
        }
    }
    public class OtomatUrunler : program
    {
        public static int[] adetler = new int[5] { 6, 6, 6, 6, 6};
        public static string[] urunler = new string[5] { "fanta", "kola", "cikolata", "cubuk_kraker", "su" };
        public static int[] fiyatlar = new int[5] { 50, 45, 55, 30, 10 };
        public static int[] satislar = new int[0];
        public static int toplamsatis = 0;

        public static void UrunListele()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i + "." + urunler[i] + "=" + fiyatlar[i] + "TL");
            }

        }
         public static int ParaKontrol(int secim, int para)
        {
            while (para != -1)
            {
                if (para > fiyatlar[secim])
                {
                    Console.WriteLine("Urunu Otomattan Alabilirsin. ");
                    Kalan_Para_Hesapla(secim, para);
                    Array.Resize(ref satislar, satislar.Length + 1);
                    
                    toplamsatis += fiyatlar[secim];
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
                {
                    Console.WriteLine("Urunu Otomattan Alabilirsiniz.");
                    Array.Resize(ref satislar, satislar.Length + 1);
                    toplamsatis += fiyatlar[secim];
                }
                break;
            }
            return 0;
        }


        public static int Kalan_Para_Hesapla(int secim, int para)
        {

            int kalan_para = para - fiyatlar[secim];
            Console.WriteLine("Para Ustunuz: " + kalan_para + "TL Almayi Unutmayin.");

            return 0;
        }
         public static Array UrunAdetKontrol(int secim, int yeniurunekle, int uruncikarma, int urunekleme)
        {

            if (uruncikarma == 1)
            {
                if (0 < adetler[secim])
                {
                    
                    adetler[secim] -= 1;

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
                if (adetler[secim] == 0)
                {
                    adetler[secim] += 1;
                    Console.WriteLine("Yeni Urunler hazneye eklendi.");
                }

                else if (adetler[secim]!= 0)
                {
                    Console.WriteLine("Bu haznede farkli cins ürünler mevcut oldugundan yeni ürün ekleyemezsin..");
                }
            }

            return adetler;
        }
    }
}