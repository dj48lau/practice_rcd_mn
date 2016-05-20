using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using NetRom.FileManagement.DAL;

namespace Netrom.FileManagement.BusinessLogic.Services
{
    public class FileService
    {
        private readonly FileRepository _fileRepository;
        private readonly FileTypeRepository _fileTypeRepository;

        public FileService() 
        {
            _fileRepository = new FileRepository();
            _fileTypeRepository = new FileTypeRepository();
        }

        public List<Model.File> GetAllFiles()
        {
           
           return _fileRepository.GetAllFiles();
                   

        }

        public void GetFilesByName(string name)
        {
            var 
 
        }
        public void SaveFile(string filePath)
        {
            //get the extension from fileName
            //string extension = fileName.Split('.')[1];
          

            //In order to get the data file 
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);

            File f = new File()
            {
                Name = fileInfo.Name,
                Size = fileInfo.Length,
                CreationDate = fileInfo.CreationTime
            };
            

            var fileType = _fileTypeRepository.GetFileType(fileInfo.Extension.Replace(".", ""));


            if (fileType != null)
            {
                f.FileTypeId = fileType.FileTypeId;
            }
            _fileRepository.WriteFile(f);
        }
    }
}
