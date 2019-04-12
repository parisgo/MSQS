using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSQS.Core
{
    [Serializable]
    public class LogItem
    {
        public string Info { get; set; }
        public DateTime AddTime { get; set; }

        public override string ToString()
        {
            return string.Format("Info={0}, AddTime={1}", Info, AddTime.ToString());
        }
    }
}
