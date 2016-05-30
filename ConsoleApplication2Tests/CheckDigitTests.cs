using Microsoft.VisualStudio.TestTools.UnitTesting;
using ISBNnumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBNnumber.Tests
{
    [TestClass()]
    public class CheckDigitTests
    {
        [TestMethod()]
        public void CheckIsbnTest_Condition1()
        {                        
            var checkDigit = new CheckDigit();
            string returned = CheckDigit.CheckIsbn("978155192370");

            Assert.AreEqual("155192370x", returned);            
        }

        public void CheckIsbnTest_Condition2()
        {
            var checkDigit = new CheckDigit();
            string returned = CheckDigit.CheckIsbn("978140007917");

            Assert.AreEqual("1400079179", returned);
        }

        public void CheckIsbnTest_Condition3()
        {
            var checkDigit = new CheckDigit();
            string returned = CheckDigit.CheckIsbn("978037541457");

            Assert.AreEqual("0375414576", returned);
        }

        public void CheckIsbnTest_Condition4()
        {
            var checkDigit = new CheckDigit();
            string returned = CheckDigit.CheckIsbn("978037428158");

            Assert.AreEqual("0374281580", returned);
        }
    }
}