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
        }

        public List<Model.File> GetAllFiles()
        {
           return _fileRepository.GetAllFiles();
        }

        public void SaveFile(string fileName)
        {
            //get the extension from fileName
            string extension = fileName.Split('.')[1];

            //In order to get the data file 
           File f = new File()
            {
                Name = fileName,
                Size = 22,
                CreationDate = System.DateTime.Now
            };

            var fileType = _fileTypeRepository.GetFileType(extension);
            if (fileType != null)
            {
                f.FileTypeId = fileType.FileTypeId;
            }
            _fileRepository.WriteFile(f);
        }
    }
}
