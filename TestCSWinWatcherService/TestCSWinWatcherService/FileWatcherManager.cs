using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestCSWinWatcherService
{
    public class FileWatcherManager
    {
        private FileSystemWatcher _watcher;

        private EventLogger _eventLogger;
        
        public void Init()
        {
            _watcher = new FileSystemWatcher(ConfigurationManager.AppSettings["WatchPath"]);

            _watcher.EnableRaisingEvents = true;
            _watcher.IncludeSubdirectories = false;

            _eventLogger = new EventLogger();
            _eventLogger.InitLog();
            
            _watcher.Created += _watcher_FileCreated;
            _watcher.Changed += _watcher_FileChanged;
            _watcher.Deleted += _watcher_FileDeleted;

            
        }

        private void _watcher_FileDeleted(object sender, FileSystemEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void _watcher_FileChanged(object sender, FileSystemEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void _watcher_FileCreated(object sender, FileSystemEventArgs e)
        {
            Thread.Sleep(100);
           
            try
            {
                System.IO.File.Copy(e.FullPath, _watcher.Path + "\\TxtFolder\\" + e.Name);
            }
            catch (Exception ex)
            {
                _eventLogger._writeToLog(ex);

            }
        }
    }
}
