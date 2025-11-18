using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ödev3
{
    public class Node
    {
        public int bilgi;
        public Node next;
        public Node(int veri)
        {
            bilgi = veri;
            next = null;
        }
    }
    public class Program
    {
        public Node tail;
        public int Boyut;
        public Program()
        {
            this.tail = null;
            this.Boyut = 0;
        }


        public void basaEkle(int veri)
        {
            Node yeniNode = new Node(veri);
            if(tail == null)// Liste boşsa
            {
                tail = yeniNode;    //yeni düğüm kuyruk olur
                tail.next = yeniNode; // Daire yapısını sağlamak için kendine işaret eder
            }
            else
            {
                yeniNode.next=tail.next;// Yeni düğüm, kuyruktan sonra gelen ilk düğüm olur
                tail.next = yeniNode; // Kuyruk, yeni düğümü ilk düğüm olarak işaret eder

            }
            Boyut++;
        }


        public void sonaEkle(int veri)
        {
            Node yeniNode = new Node(veri);
            if(tail == null) //her zamanki gibi önce listenin boş olup olmadığını kontrol edeceğiz
            {
                tail=yeniNode;
                tail.next = tail;
            }
            else
            {
                yeniNode.next = tail.next; // Yeni düğüm, ilk düğümden önceki düğüm olarak ayarlanır
                tail.next = yeniNode; // Kuyruk, yeni düğümü takip eder
                tail = yeniNode; // Kuyruk güncellenir
            }
            Boyut++;

        }


        public void ortayaEkle(int veri, int yer)
        {
            if (yer < 0 || yer > this.Boyut) // Kontrolü güncelledik: yer > this.Boyut
            {
                Console.WriteLine("Geçersiz pozisyon girişimi");
                return;
            }
            if (yer == 0)
            {
                basaEkle(veri);
            }
            else if (yer == Boyut)
            {
                sonaEkle(veri);
            }
            else
            {
                Node yeniDugum = new Node(veri);
                Node mevcut = tail.next; // Listenin başından başla
                for (int i = 0; i < yer - 1; i++)
                { // Pozisyona kadar ilerle
                    mevcut = mevcut.next;
                }
                yeniDugum.next = mevcut.next; // Yeni düğüm, mevcut düğümden sonrasına bağlanır
                mevcut.next = yeniDugum; // Mevcut düğüm, yeni düğümü takip eder
                Boyut++;
            }
        }

        public void bastanSil()
        {
            if (tail == null)
            {
                Console.WriteLine("Liste boş!"); // Boş liste kontrolü
                return;
            }
            if (tail.next == tail)
            { // Tek düğüm varsa
                tail = null; // Listeyi boş yap
            }
            else
            {
                tail.next = tail.next.next; // Kuyruk, baştaki düğümü atlayarak bir sonrakini takip eder
            }
            Boyut--;
        }

        public void sondanSil()
        {
            if (tail == null)
            {
                Console.WriteLine("Liste boş!");
                return;
            }
            if (tail.next == tail)
            { // Tek düğüm varsa
                tail = null;
            }
            else
            {
                Node mevcut = tail.next; // İlk düğümden başla
                while (mevcut.next != tail)
                { // Kuyruğa kadar ilerle
                    mevcut = mevcut.next;
                }
                mevcut.next = tail.next; // Kuyruğu atlayarak dairesel bağlantıyı korur
                tail = mevcut; // Kuyruk, mevcut düğüm olur
            }
            Boyut--;
        }

        public void ortadanSil(int pozisyon)
        {
            if (pozisyon < 0 || pozisyon >= Boyut)
            {
                Console.WriteLine("Geçersiz pozisyon!");
                return;
            }
            if (pozisyon == 0)
            { // Baştan silme
                bastanSil();
            }
            else if (pozisyon == Boyut - 1)
            { // Sondan silme
                sondanSil();
            }
            else
            {
                Node mevcut = tail.next; // İlk düğümden başla
                for (int i = 0; i < pozisyon - 1; i++)
                { // Pozisyona kadar ilerle
                    mevcut = mevcut.next;
                }
                mevcut.next = mevcut.next.next; // Mevcut düğüm, silinecek düğümü atlar
                Boyut--;
            }
        }

        // Listeyi görüntüleme metodu
        public void listeyiGoster()
        {
            if (tail == null)
            {
               Console.WriteLine("Liste boş!");
                return;
            }
            Node mevcut = tail.next; // Baş düğümden başla
            do
            {
                Console.WriteLine(mevcut.bilgi + " "); // Düğüm verisini yazdır
                mevcut = mevcut.next; // Bir sonrakine geç
            } while (mevcut != tail.next); // Kuyruğun tekrar başa dönmesiyle sona gelir
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            Program liste = new Program();
            int secim; 

            do
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz:" +
                    "\n1 - Listeye ekleme" +
                    "\n2 - Listeden çıkarma" +
                    "\n3 - Listeyi yazdırma" +
                    "\n4 - Çıkış için basınız");

                secim = Convert.ToInt32(Console.ReadLine());

                if (secim == 1)
                {
                    Console.WriteLine("Listeye nereden eklemek istediğinizi seçiniz:" +
                        "\n1 - Baştan ekleme" +
                        "\n2 - Sondan ekleme" +
                        "\n3 - Pozisyondan ekleme");
                    int giris = Convert.ToInt32(Console.ReadLine());

                    if (giris == 1)
                    {
                        Console.WriteLine("Lütfen başa eklemek istediğiniz sayıyı giriniz:");
                        liste.basaEkle(Convert.ToInt32(Console.ReadLine()));
                    }
                    else if (giris == 2)
                    {
                        Console.WriteLine("Lütfen sona eklemek istediğiniz sayıyı giriniz:");
                        liste.sonaEkle(Convert.ToInt32(Console.ReadLine()));
                    }
                    else
                    {
                        Console.WriteLine("Lütfen pozisyona eklemek istediğiniz sayıyı ve yerini giriniz:");
                        liste.ortayaEkle(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                    }
                }
                else if (secim == 2)
                {
                    Console.WriteLine("Listenin neresinden çıkarma yapmak istersiniz:" +
                        "\n1 - Baştan çıkarma" +
                        "\n2 - Sondan çıkarma" +
                        "\n3 - Pozisyondan çıkarma");
                    int giris = Convert.ToInt32(Console.ReadLine());

                    if (giris == 1)
                    {
                        liste.bastanSil();
                    }
                    else if (giris == 2)
                    {
                        liste.sondanSil();
                    }
                    else
                    {
                        Console.WriteLine("Lütfen pozisyondan silmek istediğiniz yeri giriniz:");
                        liste.ortadanSil(int.Parse(Console.ReadLine()));
                    }
                }
                else if (secim == 3)
                {
                    liste.listeyiGoster();
                }
                else if (secim != 4)
                {
                    Console.WriteLine("Geçersiz seçim! Lütfen tekrar deneyin.");
                }

            } while (secim != 4); // secim 4 olmadığında döngü devam eder

          
            Console.ReadLine();
        }
    }
}
