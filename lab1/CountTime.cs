using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountTimeAndExport2EXCEL
{
    class CountTime
    {
        Action<List<int>> function;
        Stopwatch counter;

        public CountTime(Action<List<int>> func)
        {
            function = func;
            counter = new Stopwatch();
        }

        public IEnumerable<Element> StartCount()
        {
            var mas = new List<Element>();
            long countELem = 1;
            for (int i = 0; i < 25; i++)
            {
                List<int> m = new List<int>();
                Random rnd = new Random();
                for (int j = 0; j < countELem; j++)
                {
                    m.Add(rnd.Next());
                }
                counter.Reset();
                counter.Start();
                //function(m);
                function.Invoke(m);
                counter.Stop();
                mas.Add(new Element(countELem, counter.ElapsedMilliseconds));
                countELem *= 2;
            }
            return mas;
        }
    }
}
