using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace NetRom.FileManagement.DAL
{

    public class FileManagementContext : DbContext
    {
        
        public FileManagementContext()
            : base("Data Source=NETROM-15;Initial Catalog=NetRom.FileManagement.Development;Persist Security Info=True;User ID=sa; Password=sql@dmin123")
        {
        }

        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyValue> PropertyValues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }

}
