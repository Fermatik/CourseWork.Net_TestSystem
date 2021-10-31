using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public static  class DirectoryAndFileTests
    {
        public static readonly string NameDirectoryForTests = "Tests";        
        public static readonly string ExtentionFileForTest = ".test";
        public static readonly string nameDirectoryForImage = "ImageForQuestion";

        public static void InitDirectory(string nameDirectory)
        {
            if (!Directory.Exists(nameDirectory))
                Directory.CreateDirectory(nameDirectory);
        }

        public static string GetNewNameForTest()
        {   
            DateTime now = DateTime.Now;
            string newName = 
                String.Format("{0:D4}", now.Year) +"_"+
                String.Format("{0:D2}", now.Month) + "_" +
                String.Format("{0:D2}", now.Day) + "_" +
                String.Format("{0:D2}", now.Hour) + "_" +
                String.Format("{0:D2}", now.Minute) + "_" +
                String.Format("{0:D2}", now.Second);

            return newName;
        }
    }
}
