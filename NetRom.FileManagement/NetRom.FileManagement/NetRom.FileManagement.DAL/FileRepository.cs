using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

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

        public void WriteFile(File file)
        {
            _dbContext.Files.Add(file);
            _dbContext.SaveChanges();
        }

        public File GetFilesByName(string text)
        {
           return _dbContext.Files.Where(f => f.Name.Contains(text));
        }
    }
}
