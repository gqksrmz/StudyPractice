using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plusoft.Utilities;

namespace DAL.Tests
{
    [TestClass()]
    public class BookInfoDalTests
    {
        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCountTest()
        {
            string sql = @"select count(*) from BookInfo";
            Console.WriteLine(DapperHelper.ExecuteScalar<int>(sql));
        }
    }
}