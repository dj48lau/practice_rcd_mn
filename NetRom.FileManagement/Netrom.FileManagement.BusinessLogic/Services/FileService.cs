using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetRom.FileManagement.DAL;
using NetRom.FileManagement.Model;

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

        public List<NetRom.FileManagement.Model.File> GetAllFiles()
        {
            return _fileRepository.GetAllFiles();
        }

        public void SaveFile(string filePath)
        {
            //In order to get the data file 
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);

            File f = new File()
            {
                Name = fileInfo.Name,
                Size = fileInfo.Length,
                CreationDate = fileInfo.CreationTime
            };

            string fileTypeName = fileInfo.Extension.Replace(".", "");
            var fileType = _fileTypeRepository.GetFileType(fileTypeName);

            if (fileType != null)
            {
                f.FileTypeId = fileType.FileTypeId;
            }
            else
            {
                 FileType ft = new FileType();
                 ft.TypeName = fileTypeName;
                _fileTypeRepository.AddFileType(ft);
                 f.FileTypeId = ft.FileTypeId;

            }
            _fileRepository.AddFile(f);
        }

        public List<FileType> GetAllFileTypes()
        {
            return _fileTypeRepository.GetAllFileType();
        }

        public List<NetRom.FileManagement.Model.File> GetFilesByName(string text)
        {
            return _fileRepository.GetFilesByName(text);
        }

        public List<NetRom.FileManagement.Model.File> GetFiles(string text, IEnumerable<FileType> fileTypes, DateTime startDate, DateTime endDate)
        {
            return _fileRepository.GetFiles(text, fileTypes, startDate, endDate);
        }
    }
}
