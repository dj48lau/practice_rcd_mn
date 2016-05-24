using NetRom.FileManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetRom.FileManagement.DAL
{
    public class FileTypeRepository
    {
        private readonly FileManagementContext _dbContext;

        public FileTypeRepository()
        {
            _dbContext = new FileManagementContext();
        }

        public List<FileType> GetAllFileType()
        {
            return _dbContext.FileTypes.ToList();
        }

        public FileType GetFileType(string extension)
        {
            return _dbContext.FileTypes.FirstOrDefault(ft => ft.TypeName.ToLower() == extension.ToLower());
        }

        public void AddFileType(FileType fileType)
        {
            _dbContext.FileTypes.Add(fileType);
            _dbContext.SaveChanges();
        }
    }
}
