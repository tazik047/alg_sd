using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountTimeAndExport2EXCEL
{
    struct Element
    {
        public long Count;
        public long Time;

        public Element(long c, long t)
        {
            Count = c;
            Time = t;
        }

        public override string ToString()
        {
            return String.Format("Количество:{0} Время:{1}", Count, Time);
        }
    }
}
