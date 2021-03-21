using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassLock.Handler.IO
{
    public class BatchFilesHandler
    {
        public static string IsBitwardenInstalled
        {
            get { return $@"{PathHandler.BatchesFolder}\isBitwardenInstalled.bat"; }
        }

        public static string IsNPMInstalled
        {
            get { return $@"{PathHandler.BatchesFolder}\isNPMInstalled.bat"; }
        }
    }
}
