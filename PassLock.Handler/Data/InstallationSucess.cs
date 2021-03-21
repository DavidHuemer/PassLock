using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassLock.Handler.Data
{
    public class InstallationSucess
    {
        public string Software { get; set; }
        public bool Sucess { get; set; }

        public InstallationSucess(string software, bool sucess)
        {
            Software = software;
            Sucess = sucess;
        }
    }
}
