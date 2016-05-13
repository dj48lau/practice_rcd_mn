using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using NetRom.FileManagement.BusinessLogic;

namespace NetRom.FileManagement.BusinessLogic
{
     public class EventLogger
    {
        private string eventViewerSource = "TestCSWinService";
        private string eventViewerLog = "Errors";
        

         public void InitLog()
         {
            
             // init the log

             if (!EventLog.SourceExists(eventViewerSource))
             {
                 EventLog.CreateEventSource(eventViewerSource, eventViewerLog);
             }
             
              
         }

         public void _writeToLog(Exception ex)
         {
             EventLog.WriteEntry(eventViewerSource, ex.Message + ex.StackTrace);
         }

    }
}
