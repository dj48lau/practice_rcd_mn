namespace NetRom.FileManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Model;

    internal sealed class Configuration : DbMigrationsConfiguration<NetRom.FileManagement.DAL.FileManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NetRom.FileManagement.DAL.FileManagementContext context)
        {
            FileType fileType = new FileType()
            {
                TypeName = "Pdf",
                SyncInMin = 1,
                Path = "SomePath"
            };
            context.FileTypes.AddOrUpdate(fileType);

            File file = new File()
            {
                FileTypeId = fileType.FileTypeId,
                Name = "First file name",
                Size = 22222,
                CreationDate = DateTime.Now
            };
            context.Files.AddOrUpdate(file);
            
            context.SaveChanges();
        }
    }
}
