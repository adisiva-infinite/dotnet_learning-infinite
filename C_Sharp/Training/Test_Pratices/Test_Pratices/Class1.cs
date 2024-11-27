using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Test_Pratices
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Add()
        {
            var a = 10;
            var b = " Ten";
            var c = a + b;
            ClassicAssert.AreEqual("10 Ten", c);
        }
    }
}
