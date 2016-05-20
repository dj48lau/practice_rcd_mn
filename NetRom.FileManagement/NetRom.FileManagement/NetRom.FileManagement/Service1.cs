using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NetRom.FileManagement.BusinessLogic;

namespace NetRom.FileManagement.WS
{
    public partial class Service1 : ServiceBase
    {
        private FileWatcherManager _fileWatcherManager;
       

        public Service1()
        {
        }

        protected override void OnStart(string[] args)
        {

            _fileWatcherManager = new FileWatcherManager();
            _fileWatcherManager.Init();
            
            
        }

        protected override void OnStop()
        {
        }
    }
}
