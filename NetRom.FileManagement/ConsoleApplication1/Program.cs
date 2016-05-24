using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Netrom.FileManagement.BusinessLogic.Services;
using NetRom.FileManagement.BusinessLogic;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileWatcherManager fm = new FileWatcherManager();
            fm.Init();         
           
            Console.ReadKey();
        }
    }
}
