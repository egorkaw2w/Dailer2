using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dailer2
{
    internal class Zametki
    {
        public string name  { get; set; }
        public string description;
        public DateTime data;

        public Zametki(string Name, string Description, DateTime Data)
        {
            this.name = Name;
            this.description = Description;
            this.data = Data;
        }

    }
}
