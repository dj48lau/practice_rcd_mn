using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Netrom.FileManagement.BusinessLogic.Services;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //init the service
            FileService fileService = new FileService();

            //get all files
            var filesList = fileService.GetAllFiles();

            var file = new File()
            {
                Name = "Mona",
                FileTypeId = 1,
                Size = 12,
                CreationDate = System.DateTime.Now
            };

            Console.WriteLine(filesList.Count);
            Console.ReadKey();
        }
    }
}
