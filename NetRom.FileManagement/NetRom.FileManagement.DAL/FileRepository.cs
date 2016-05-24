using NetRom.FileManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetRom.FileManagement.DAL
{
    public class FileRepository
    {
        private readonly FileManagementContext _dbContext;

        public FileRepository()
        {
            _dbContext = new FileManagementContext();
        }

        public List<File> GetAllFiles()
        {
            return _dbContext.Files.ToList();
        }

        public void AddFile(File file)
        {
            _dbContext.Files.Add(file);
            _dbContext.SaveChanges();
        }

        public List<File> GetFilesByName(string text)
        {
            return _dbContext.Files.Where(f => f.Name.Contains(text)).ToList();
        }

        public List<File> GetFiles(string text, IEnumerable<FileType> fileTypes, DateTime startDate, DateTime endDate)
        {
            // Filter the files based on textkey.
            var filesQuery = _dbContext.Files.Where(f => f.Name.Contains(text));


            // Filter the files based on FileTypes.
            var fileTypeIds = fileTypes.Select(ft => ft.FileTypeId);
            filesQuery = filesQuery.Where(f => fileTypeIds.Contains(f.FileTypeId));

            // If there is a start date take only the files created after that date.
            if (startDate != null)
            {
                filesQuery = filesQuery.Where(f => f.CreationDate > startDate);
            }

            // If there is a end date take only the files created before that date.
            if (endDate !=null)
            {
                filesQuery = filesQuery.Where(f => f.CreationDate < endDate);
            }

            return filesQuery.ToList();
        }
    }
}
