using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTP_4s._1;

namespace MTP_4s_Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestAppendcapacity()
        {
            HashSet<int> hs = new HashSet<int>();
            hs.Add(7);
            Assert.AreEqual(10, hs.Capacity);
            hs.Add(28);
            Assert.AreEqual(20, hs.Capacity);
        }
        [TestMethod]
        public void TestAddingToEmptySet()
        {
            HashSet<int> hs = new HashSet<int>();
            hs.Add(77);
            Assert.AreEqual(1, hs.Count);
            hs.Clear();
            hs.Add(77);
            Assert.AreEqual(1, hs.Count);
        }
        [TestMethod]
        public void TestRemovingToEmptySet()
        {
            HashSet<int> hs = new HashSet<int>();
            hs.Add(77);
            Assert.AreEqual(1, hs.Count);
            hs.Clear();
            hs.Remove(1);
            Assert.AreEqual(0, hs.Count);
        }
        [TestMethod]
        public void TestContainsToEmptySet()
        {
            HashSet<int> hs = new HashSet<int>();
            hs.Add(77);
            Assert.AreEqual(1, hs.Count);
            hs.Clear();
            Assert.AreEqual(false, hs.Contains(77));
        }
        [TestMethod]
        public void TestAddingSameValues()
        {
            HashSet<int> hs = new HashSet<int>();
            hs.Add(77);
            hs.Add(77);
            hs.Add(77);
            Assert.AreEqual(1, hs.Count);
        }
        [TestMethod]
        public void TestAdd()
        {
            HashSet<int> hs = new HashSet<int>();
            hs.Add(7);
            hs.Add(77);
            hs.Add(777);
            Assert.AreEqual(3, hs.Count);
        }
        [TestMethod]
        public void TestContains()
        {
            HashSet<int> hs = new HashSet<int>();
            hs.Add(7);
            hs.Add(77);
            hs.Add(777);
            Assert.AreEqual(true, hs.Contains(7));
        }
        [TestMethod]
        public void TestRemoveCount()
        {
            HashSet<int> hs = new HashSet<int>();
            hs.Add(7);
            hs.Add(77);
            hs.Add(777);
            hs.Remove(77);
            Assert.AreEqual(2, hs.Count);
        }
        [TestMethod]
        public void TestRemoveContains()
        {
            HashSet<int> hs = new HashSet<int>();
            hs.Add(7);
            hs.Add(77);
            hs.Add(777);
            hs.Remove(77);
            Assert.AreEqual(false, hs.Contains(77));
        }
        [TestMethod]
        public void TestClear()
        {
            HashSet<int> hs = new HashSet<int>();
            hs.Add(7);
            hs.Add(77);
            hs.Add(777);
            hs.Clear();
            Assert.AreEqual(0, hs.Count);
        }
        [TestMethod]
        public void TestClearisEmpity()
        {
            HashSet<int> hs = new HashSet<int>();
            hs.Add(7);
            hs.Add(77);
            hs.Add(777);
            hs.Clear();
            Assert.AreEqual(false, hs.isEmpty);
        }
        [TestMethod]
        public void TestisEmpity()
        {
            HashSet<int> hs = new HashSet<int>();
            hs.Add(7);
            hs.Add(77);
            hs.Add(777);
            Assert.AreEqual(true, hs.isEmpty);
        }
        [TestMethod]
        public void TestUnionFirstWithSecond()
        {
            HashSet<int> hs1 = new HashSet<int>();
            HashSet<int> hs2 = new HashSet<int>();
            HashSet<int> hs3 = new HashSet<int>();
            hs1.Add(1);
            hs1.Add(2);
            hs1.Add(3);
            hs2.Add(3);
            hs2.Add(4);
            hs2.Add(5);
            hs3 = hs1.Union(hs2);
            Assert.AreEqual(5, hs3.Count);
            Assert.AreEqual(true, hs3.Contains(1));
            Assert.AreEqual(true, hs3.Contains(2));
            Assert.AreEqual(true, hs3.Contains(3));
            Assert.AreEqual(true, hs3.Contains(4));
            Assert.AreEqual(true, hs3.Contains(5));
            Assert.AreEqual(false, hs3.Contains(6));
        }
        [TestMethod]
        public void TestUnionSecondWithFirst()
        {
            HashSet<int> hs1 = new HashSet<int>();
            HashSet<int> hs2 = new HashSet<int>();
            HashSet<int> hs3 = new HashSet<int>();
            hs1.Add(1);
            hs1.Add(2);
            hs1.Add(3);
            hs2.Add(3);
            hs2.Add(4);
            hs2.Add(5);
            hs3 = hs2.Union(hs1);
            Assert.AreEqual(5, hs3.Count);
            Assert.AreEqual(true, hs3.Contains(1));
            Assert.AreEqual(true, hs3.Contains(2));
            Assert.AreEqual(true, hs3.Contains(3));
            Assert.AreEqual(true, hs3.Contains(4));
            Assert.AreEqual(true, hs3.Contains(5));
            Assert.AreEqual(false, hs3.Contains(6));
        }
        [TestMethod]
        public void TestUnionYourself()
        {
            HashSet<int> hs1 = new HashSet<int>();
            HashSet<int> hs2 = new HashSet<int>();
            hs1.Add(1);
            hs1.Add(2);
            hs1.Add(3);
            hs1.Add(3);
            hs1.Add(4);
            hs1.Add(5);
            hs2 = hs1.Union(hs1);
            Assert.AreEqual(5, hs2.Count);
            Assert.AreEqual(true, hs2.Contains(1));
            Assert.AreEqual(true, hs2.Contains(2));
            Assert.AreEqual(true, hs2.Contains(3));
            Assert.AreEqual(true, hs2.Contains(4));
            Assert.AreEqual(true, hs2.Contains(5));
            Assert.AreEqual(false, hs2.Contains(6));
        }
        [TestMethod]
        public void TestIntersectionFirstWithSecond()
        {
            HashSet<int> hs1 = new HashSet<int>();
            HashSet<int> hs2 = new HashSet<int>();
            HashSet<int> hs3 = new HashSet<int>();
            hs1.Add(1);
            hs1.Add(4);
            hs1.Add(3);
            hs2.Add(3);
            hs2.Add(4);
            hs2.Add(5);
            hs3 = hs1.Intersection(hs2);
            Assert.AreEqual(2, hs3.Count);
            Assert.AreEqual(false, hs3.Contains(1));
            Assert.AreEqual(true, hs3.Contains(3));
            Assert.AreEqual(true, hs3.Contains(4));
            Assert.AreEqual(false, hs3.Contains(5));
        }
        [TestMethod]
        public void TestIntersectionSecondWithFirst()
        {
            HashSet<int> hs1 = new HashSet<int>();
            HashSet<int> hs2 = new HashSet<int>();
            HashSet<int> hs3 = new HashSet<int>();
            hs1.Add(1);
            hs1.Add(4);
            hs1.Add(3);
            hs2.Add(3);
            hs2.Add(4);
            hs2.Add(5);
            hs3 = hs2.Intersection(hs1);
            Assert.AreEqual(2, hs3.Count);
            Assert.AreEqual(false, hs3.Contains(1));
            Assert.AreEqual(true, hs3.Contains(3));
            Assert.AreEqual(true, hs3.Contains(4));
            Assert.AreEqual(false, hs3.Contains(5));
        }
        [TestMethod]
        public void TestIntersectionYourself()
        {
            HashSet<int> hs1 = new HashSet<int>();
            HashSet<int> hs2 = new HashSet<int>();
            hs1.Add(1);
            hs1.Add(4);
            hs1.Add(3);
            hs1.Add(3);
            hs1.Add(4);
            hs1.Add(5);
            hs2 = hs1.Intersection(hs1);
            Assert.AreEqual(4, hs2.Count);
            Assert.AreEqual(true, hs2.Contains(1));
            Assert.AreEqual(true, hs2.Contains(3));
            Assert.AreEqual(true, hs2.Contains(4));
            Assert.AreEqual(true, hs2.Contains(5));
        }
        [TestMethod]
        public void TestDifferenceFirstWithSecond()
        {
            HashSet<int> hs1 = new HashSet<int>();
            HashSet<int> hs2 = new HashSet<int>();
            HashSet<int> hs3 = new HashSet<int>();
            hs1.Add(1);
            hs1.Add(2);
            hs1.Add(3);
            hs1.Add(4);
            hs2.Add(2);
            hs2.Add(3);
            hs3 = hs1.Difference(hs2);
            Assert.AreEqual(2, hs3.Count);
            Assert.AreEqual(true, hs3.Contains(1));
            Assert.AreEqual(false, hs3.Contains(2));
            Assert.AreEqual(false, hs3.Contains(3));
            Assert.AreEqual(true, hs3.Contains(4));
        }
        [TestMethod]
        public void TestDifferenceSecondWithFirst()
        {
            HashSet<int> hs1 = new HashSet<int>();
            HashSet<int> hs2 = new HashSet<int>();
            HashSet<int> hs3 = new HashSet<int>();
            hs1.Add(1);
            hs1.Add(2);
            hs1.Add(3);
            hs1.Add(4);           
            hs2.Add(2);
            hs2.Add(3);
            hs3 = hs2.Difference(hs1);
            Assert.AreEqual(0, hs3.Count);
            Assert.AreEqual(false, hs3.Contains(1));
            Assert.AreEqual(false, hs3.Contains(2));
            Assert.AreEqual(false, hs3.Contains(3));
            Assert.AreEqual(false, hs3.Contains(4));
        }
        [TestMethod]
        public void TestDifferenceYourself()
        {
            HashSet<int> hs1 = new HashSet<int>();
            HashSet<int> hs2 = new HashSet<int>();
            hs1.Add(1);
            hs1.Add(2);
            hs1.Add(3);
            hs1.Add(4);
            hs2 = hs1.Difference(hs1);
            Assert.AreEqual(0, hs2.Count);
            Assert.AreEqual(false, hs2.Contains(1));
            Assert.AreEqual(false, hs2.Contains(2));
            Assert.AreEqual(false, hs2.Contains(3));
            Assert.AreEqual(false, hs2.Contains(4));
        }
        [TestMethod]
        public void TestSubsetFull()
        {
            HashSet<int> hs1 = new HashSet<int>();
            HashSet<int> hs2 = new HashSet<int>();
            hs1.Add(1);
            hs1.Add(2);
            hs1.Add(3);
            hs1.Add(4);
            hs2.Add(1);
            hs2.Add(4);
            Assert.AreEqual(true, hs1.Subset(hs2));
        }
        [TestMethod]
        public void TestSubsetEmpty()
        {
            HashSet<int> hs1 = new HashSet<int>();
            HashSet<int> hs2 = new HashSet<int>();
            hs1.Add(1);
            hs1.Add(2);
            hs1.Add(3);
            hs1.Add(4);
            hs2.Add(5);
            hs2.Add(6);
            Assert.AreEqual(false, hs1.Subset(hs2));
        }
        [TestMethod]
        public void TestSymmetricDifferenceFirstWithSecond()
        {
            HashSet<int> hs1 = new HashSet<int>();
            HashSet<int> hs2 = new HashSet<int>();
            HashSet<int> hs3 = new HashSet<int>();
            hs1.Add(1);
            hs1.Add(2);
            hs1.Add(6);
            hs1.Add(5);
            hs2.Add(5);
            hs2.Add(6);
            hs2.Add(7);
            hs3 = hs1.SymmetricDifference(hs2);
            Assert.AreEqual(3, hs3.Count);
            Assert.AreEqual(true, hs3.Contains(1));
            Assert.AreEqual(true, hs3.Contains(2));
            Assert.AreEqual(false, hs3.Contains(5));
            Assert.AreEqual(false, hs3.Contains(6));
            Assert.AreEqual(true, hs3.Contains(7));
        }
        [TestMethod]
        public void TestSymmetricDifferenceSecondtWithFirst()
        {
            HashSet<int> hs1 = new HashSet<int>();
            HashSet<int> hs2 = new HashSet<int>();
            HashSet<int> hs3 = new HashSet<int>();
            hs1.Add(1);
            hs1.Add(2);
            hs1.Add(6);
            hs1.Add(5);
            hs2.Add(5);
            hs2.Add(6);
            hs2.Add(7);
            hs3 = hs2.SymmetricDifference(hs1);
            Assert.AreEqual(3, hs3.Count);
            Assert.AreEqual(true, hs3.Contains(1));
            Assert.AreEqual(true, hs3.Contains(2));
            Assert.AreEqual(false, hs3.Contains(5));
            Assert.AreEqual(false, hs3.Contains(6));
            Assert.AreEqual(true, hs3.Contains(7));
        }
        [TestMethod]
        public void TestSymmetricDifferenceYourself()
        {
            HashSet<int> hs1 = new HashSet<int>();
            HashSet<int> hs2 = new HashSet<int>();
            hs1.Add(1);
            hs1.Add(2);
            hs1.Add(6);
            hs1.Add(5);
            hs2 = hs1.SymmetricDifference(hs1);
            Assert.AreEqual(0, hs2.Count);
            Assert.AreEqual(false, hs2.Contains(1));
            Assert.AreEqual(false, hs2.Contains(2));
            Assert.AreEqual(false, hs2.Contains(5));
            Assert.AreEqual(false, hs2.Contains(6));
            Assert.AreEqual(false, hs2.Contains(7));
        }
    }
}