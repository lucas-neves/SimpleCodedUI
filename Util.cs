using Microsoft.VisualStudio.TestTools.UITesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedUITestProject1
{
    public class Util
    {
        public static void takeScreenshot(string testName)
        {
            string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                path = Directory.GetParent(path).ToString();
                Image evidence = UITestControl.Desktop.CaptureImage();
                evidence.Save(path + "\\Desktop\\" + testName + System.DateTime.Now.ToString("_dd-MM-yyyy hhmmssfff") + ".jpg");
            }                        
        }
    }
}
