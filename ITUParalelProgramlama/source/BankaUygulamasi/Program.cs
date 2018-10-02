using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace BankaUygulamasi
{
    public class Program
    {
        private static Object mutex_oku = new Object();
        private static Object mutex_yaz = new Object();
        const int beklemeKoltugu = 10;
        static LinkedList<Musteri> MusteriList = new LinkedList<Musteri>();
        public static LinkedList<Musteri> AlinanListesi = new LinkedList<Musteri>();
        public static List<int> AlinanListesi_ID = new List<int>();
        public static List<Musteri> TestMusteri = new List<Musteri>();
        static int ayricalikCounter = 0;

        static public void Init()
        {
            mutex_oku = new Object();
            mutex_yaz = new object();
            MusteriList = new LinkedList<Musteri>();
            AlinanListesi = new LinkedList<Musteri>();
            AlinanListesi_ID = new List<int>();
            TestMusteri = new List<Musteri>();
            ayricalikCounter = 0;
            Musteri.IdCnt = 1;
        }
    

        static public void Run(List<Musteri> _TestMusteri)
        {
            TestMusteri = _TestMusteri;
            Thread th1_bankaci = new Thread(new ThreadStart(BankaciDavranisi));
            Thread th2_bankaci = new Thread(new ThreadStart(BankaciDavranisi));
            Thread th3_bankaci = new Thread(new ThreadStart(BankaciDavranisi));
            Thread th4_bankaci = new Thread(new ThreadStart(BankaciDavranisi));

            Thread th_musteri = new Thread(new ThreadStart(MusteriDavranisi));

            th1_bankaci.Start();
            th2_bankaci.Start();
            th3_bankaci.Start();
            th4_bankaci.Start();

            th_musteri.Start();
            var allThreads = new Thread[5] { th1_bankaci, th2_bankaci, th3_bankaci, th4_bankaci, th_musteri };
            foreach (var aThread in allThreads)
            {
                aThread.Join();
            }
            //Console.ReadLine();
        }
        static void Main(string[] args)
        {
            List<Musteri> TestMusteri = new List<Musteri>(){
                new Musteri(false), //1
                new Musteri(true), //2
                new Musteri(true), //3
                new Musteri(true), //4
            };
            List<Musteri> TestMusterix4 = new List<Musteri>(){
                new Musteri(false), //1
                new Musteri(false), //2
                new Musteri(false), //3
                new Musteri(true), //4
            };
            List<Musteri> TestMusterix3 = new List<Musteri>(){
                new Musteri(false), //1
                new Musteri(true), //2
                new Musteri(false), //3
            };
            List<Musteri> TestMusterix1 = new List<Musteri>(){
                new Musteri(false), //1
                new Musteri(false), //2
                new Musteri(false), //3
                new Musteri(false), //4
            };
            List<Musteri> TestMusterix = new List<Musteri>(){
                new Musteri(false), //1
                new Musteri(true), //2
                new Musteri(false), //3
                new Musteri(true), //4
                new Musteri(true), //5
                new Musteri(false), //6
                new Musteri (false), //7
                new Musteri (false),//8
                new Musteri (false),//9
                new Musteri (true),//10
                new Musteri (false),//11
                new Musteri (false),//12
                new Musteri (false),//13
                new Musteri (false),//14
                new Musteri (true),//15
                new Musteri (false),//16
                new Musteri (true),//17
                new Musteri (true),//18
                new Musteri (false),//19
                new Musteri (false),//20
                new Musteri (true),//21
            };
            Run(TestMusteri);
        }


        static void BankaciDavranisi()
        {
            while (TestMusteri.Count != 0 || MusteriList.Count != 0)
            {
                if (MusteriList.Count != 0)
                {
                    Musteri m = new Musteri();
                    lock (mutex_oku)
                    {
                        m = Get();
                        if (m != null)
                        {
                            AlinanListesi.AddLast(m);
                            AlinanListesi_ID.Add(m.id);
                            Console.WriteLine("Bankaci PID: " + Thread.CurrentThread.ManagedThreadId.ToString() + " isleme alinan musteri: " + m.id.ToString() + " " + m.AyricalikliMi());
                            Thread.Sleep(100);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Bankaci PID: " + Thread.CurrentThread.ManagedThreadId.ToString() + " waiting");
                    Thread.Sleep(10000);
                    //Console.Read();
                }
            }
        }


        static void MusteriDavranisi()
        {
            while (TestMusteri.Count != 0)
            {
                lock (mutex_yaz)
                {
                    Add(TestMusteri.ElementAt(0));
                    TestMusteri.RemoveAt(0);
                }
                Thread.Sleep(100);
                
            }
        }

        static void Add(Musteri musteri)
        {
            if (MusteriList.Count == beklemeKoltugu + 5)
            {
                Console.WriteLine("Şu an doluyuz, sonra geliniz");
                //Console.Read();
                return;
            }
            Console.WriteLine("Added: " + musteri.id.ToString() + " " + musteri.AyricalikliMi());
            if (Musteri.IdCnt == int.MaxValue - 2)
            {
                Console.WriteLine("müsteri sayisi costu: ", Musteri.IdCnt);
            }
            MusteriList.AddLast(musteri);
        }
        static Musteri Get()
        {
            var node = MusteriList.First;
            if (node == null)
            {
                return null;
            }
            var m1 = MusteriList.ElementAt(0);
            if (m1.ayricalikli && ayricalikCounter < 2)
            {
                MusteriList.Remove(node);
                return m1;
            }
            if (MusteriList.Count < 2)
            {
                MusteriList.Remove(m1);
                ayricalikCounter = 0;
                return m1;
            }

            var m2 = MusteriList.ElementAt(1);
            node = node.Next;
            if (m2.ayricalikli && ayricalikCounter < 2)
            {
                MusteriList.Remove(node);
                ayricalikCounter++;
                return m2;
            }
            if (MusteriList.Count < 3)
            {
                MusteriList.Remove(m1);
                ayricalikCounter = 0;
                return m1;
            }

            node = node.Next;
            var m3 = MusteriList.ElementAt(2);
            if (m3.ayricalikli && ayricalikCounter < 2)
            {
                MusteriList.Remove(node);
                ayricalikCounter++;
                return m3;
            }
            MusteriList.Remove(m1);
            ayricalikCounter = 0;
            return m1;
        }


    }


    public class Musteri
    {
        public static int IdCnt = 1;
        public int id;
        public bool ayricalikli;
        public Musteri(bool _ayricalikli = false)
        {
            id = IdCnt;
            IdCnt++;
            ayricalikli = _ayricalikli;
        }
        public string AyricalikliMi()
        {
            if(ayricalikli)
            {
                return "Ayricalikli";
            }
            return "Normal";
        }
    }
}

