using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC6.Grid.REST.ECRM.Loyalty.Core.Helpers;
using MVC6.Grid.REST.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC6.Grid.REST.Tests
{
    [TestClass]
    public class TestStrings
    {

        [TestMethod]
        public void TestEQUALS()
        {

            var temp = new DummyEnumerable();
            var dummies = temp.Dummies.AsQueryable();

            var tfilter = new TableFilterBuilder()
            {
                Field = "Id",
                Operator = "EQUALS",
                Value = "1"
            };

            var expected = dummies.ElementAt(0);

            var actual = tfilter.FilterWithCondition(dummies).First();

            Assert.AreEqual(expected, actual);

        }


        [TestMethod]
        public void TestNOT_EQUALS()
        {

            var temp = new DummyEnumerable();
            var dummies = temp.Dummies.AsQueryable();

            // Daniele
            var tfilter = new TableFilterBuilder()
            {
                Field = "Id",
                Operator = "NOT_EQUALS",
                Value = "1"
            };

            var expected = dummies.Where(w => w.Id != 1);

            var actual = tfilter.FilterWithCondition(dummies);

            Assert.AreEqual(expected.First(), actual.First());

        }
    }
}
