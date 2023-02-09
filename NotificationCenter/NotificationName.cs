using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCenter
{
    public class NotificationName
    {
        public string name { get; }
        public NotificationName(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
