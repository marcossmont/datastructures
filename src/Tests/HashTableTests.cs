using Hashtalbe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestClass]
    public class HashtableTests
    {
        MyHashTable<string, string> hashtable;
        [TestInitialize]
        public void SetUp()
        {
            hashtable = new MyHashTable<string, string>(8);

            hashtable.Add("John", "John Smith");
            hashtable.Add("Mary", "Mary Smith");
            hashtable.Add("Jacob", "Jacob Smith");
            hashtable.Add("Thomas", "Thomas Smith");
        }

        [TestMethod]
        public void Hashtalbe_Add()
        {
            hashtable.Add("Ane", "Ane Smith");

            Assert.AreEqual(hashtable.GetByKey("John").Value, "John Smith");
            Assert.AreEqual(hashtable.GetByKey("Mary").Value, "Mary Smith");
            Assert.AreEqual(hashtable.GetByKey("Jacob").Value, "Jacob Smith");
            Assert.AreEqual(hashtable.GetByKey("Thomas").Value, "Thomas Smith");
            Assert.AreEqual(hashtable.GetByKey("Ane").Value, "Ane Smith");
        }

        [TestMethod]
        public void Hashtalbe_Update()
        {
            hashtable.Update("John", "John Johnson");

            Assert.AreEqual(hashtable.GetByKey("John").Value, "John Johnson");
            Assert.AreEqual(hashtable.GetByKey("Mary").Value, "Mary Smith");
            Assert.AreEqual(hashtable.GetByKey("Jacob").Value, "Jacob Smith");
            Assert.AreEqual(hashtable.GetByKey("Thomas").Value, "Thomas Smith");
        }

        [TestMethod]
        public void Hashtalbe_Remove()
        {
            hashtable.Remove("John");

            Assert.IsNull(hashtable.GetByKey("John"));
            Assert.AreEqual(hashtable.GetByKey("Mary").Value, "Mary Smith");
            Assert.AreEqual(hashtable.GetByKey("Jacob").Value, "Jacob Smith");
            Assert.AreEqual(hashtable.GetByKey("Thomas").Value, "Thomas Smith");
        }

        [TestMethod]
        public void Hashtalbe_Add_Resize()
        {
            hashtable.Add("Ane", "Ane Smith");
            hashtable.Add("Jane", "Jane Smith");
            hashtable.Add("Terry", "Terry Smith");
            hashtable.Add("Rick", "Rick Smith");

            Assert.AreEqual(hashtable.GetByKey("John").Value, "John Smith");
            Assert.AreEqual(hashtable.GetByKey("Mary").Value, "Mary Smith");
            Assert.AreEqual(hashtable.GetByKey("Jacob").Value, "Jacob Smith");
            Assert.AreEqual(hashtable.GetByKey("Thomas").Value, "Thomas Smith");
            Assert.AreEqual(hashtable.GetByKey("Ane").Value, "Ane Smith");
            Assert.AreEqual(hashtable.GetByKey("Jane").Value, "Jane Smith");
            Assert.AreEqual(hashtable.GetByKey("Terry").Value, "Terry Smith");
            Assert.AreEqual(hashtable.GetByKey("Rick").Value, "Rick Smith");
        }

    }
}
