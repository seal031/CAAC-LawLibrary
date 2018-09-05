using Microsoft.VisualStudio.TestTools.UnitTesting;
using CAAC_LawLibrary.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAC_LawLibrary.DAL.Tests
{
    [TestClass()]
    public class DbHelperTests
    {
        [TestMethod()]
        public void getLawsTest()
        {
            DbHelper db = new DbHelper();
            var a= db.getLaws(new Utity.QueryParam() { lawId="821"});
            Assert.Fail();
        }
    }
}