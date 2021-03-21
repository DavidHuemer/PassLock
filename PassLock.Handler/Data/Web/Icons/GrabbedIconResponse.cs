using System.Collections.Generic;

namespace PassLock.Handler.Data.Web.Icons
{
    public class GrabbedIconResponse
    {
        public string Domain { get; set; } = "";
        public List<GrabbedIcon> Icons { get; set; } = new List<GrabbedIcon>();
    }
}
