using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN.MenuManagement
{
    public abstract class HNMenuBase
    {
        public HNMenuBase()
        {
            Location = string.Empty;
        }

        public HNMenuBase(string location)
        {
            Location = location;
        }

        public string Location { get; set; }

        public abstract List<HNMenuItem> Load();
    }
}
