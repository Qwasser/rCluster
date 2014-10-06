using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WorkerNode;

namespace WorkerNodeTest
{
    [TestFixture]
    public class RThreadTest
    {
        [Ignore]

        [TestCase(" -e \"42\" ", @"C:\Program Files\R\R-3.1.1\bin\x64\Rscript")]
        [TestCase(" -e \" install.packages('sdsdsdsd')\" ", @"C:\Program Files\R\R-3.1.1\bin\x64\Rscript")]
        public void ExitMessageTest(String script, String rPath)
        {
            var rThread = new RThread(script, rPath);
            
            System.Threading.Thread.Sleep(5000);
        }
    }
}
