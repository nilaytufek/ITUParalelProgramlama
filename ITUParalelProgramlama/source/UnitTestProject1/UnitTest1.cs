using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BankaUygulamasi;
using System;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Case1()
        {
            Program.Init();
            List<int> BeklenenAlinmaSirasi = new List<int>() { 1, 2, 3 };
            List<Musteri> TestMusteriList = new List<Musteri>(){
                new Musteri (false), //1
                new Musteri (false), //2
                new Musteri (false), //3
            };
            Program.Run(TestMusteriList);
            Console.WriteLine(BeklenenAlinmaSirasi);
            Console.WriteLine(Program.AlinanListesi_ID);
            Assert.IsTrue(BeklenenAlinmaSirasi.SequenceEqual(Program.AlinanListesi_ID));
            //Assert.AreEqual(BeklenenAlinmaSirasi, Program.AlinanListesi_ID);
        }
        [TestMethod]
        public void Case2()
        {
            Program.Init();
            List<int> BeklenenAlinmaSirasi = new List<int>() { 2, 1, 3 };
            List<Musteri> TestMusteriList = new List<Musteri>(){
                new Musteri (false), //1
                new Musteri (true), //2
                new Musteri (false), //3
            };
            Program.Run(TestMusteriList);
            Console.WriteLine(BeklenenAlinmaSirasi);
            Console.WriteLine(Program.AlinanListesi_ID);
            Assert.IsTrue(BeklenenAlinmaSirasi.SequenceEqual(Program.AlinanListesi_ID));
        }
        [TestMethod]
        public void Case3()
        {
            Program.Init();
            List<int> BeklenenAlinmaSirasi = new List<int>() { 1, 4, 2, 3 };
            List<Musteri> TestMusteriList = new List<Musteri>(){
                new Musteri (false), //1
                new Musteri (false), //2
                new Musteri (false), //3
                new Musteri (true), //3
            };
            Program.Run(TestMusteriList);
            Console.WriteLine(BeklenenAlinmaSirasi);
            Console.WriteLine(Program.AlinanListesi_ID);
            Assert.IsTrue(BeklenenAlinmaSirasi.SequenceEqual(Program.AlinanListesi_ID));
        }
        [TestMethod]
        public void Case4()
        {
            Program.Init();
            List<int> BeklenenAlinmaSirasi = new List<int>() { 2, 3, 1, 4 };
            List<Musteri> TestMusteriList = new List<Musteri>(){
                new Musteri (false), //1
                new Musteri (true), //2
                new Musteri (true), //3
                new Musteri (true), //3
            };
            Program.Run(TestMusteriList);
            Console.WriteLine(BeklenenAlinmaSirasi);
            Console.WriteLine(Program.AlinanListesi_ID);
            Assert.IsTrue(BeklenenAlinmaSirasi.SequenceEqual(Program.AlinanListesi_ID));
        }
    }
}
