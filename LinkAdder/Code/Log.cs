using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkAdder.Code
{
    class Log
    {
        static Log()
        {
            using (StreamWriter outputLogFile = new StreamWriter(@"C:\Renamelog.txt"))
            {
                outputLogFile.WriteLine("oldLink;newLink",true);
            }
        }
        public static void Write(string message)
        {
            using (StreamWriter outputLogFile = new StreamWriter(@"C:\Renamelog.txt", true))
            {
                    outputLogFile.WriteLine(message);
            }
        }
    }
}
