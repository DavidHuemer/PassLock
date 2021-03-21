using System;

namespace PassLock.Handler.IO
{
    public static class PathHandler
    {
        public static string ExeFolder
        {
            get { return AppDomain.CurrentDomain.BaseDirectory; }
        }

        public static string BatchesFolder
        {
            get { return $@"{ExeFolder}\Batches"; }
        }
    }
}
