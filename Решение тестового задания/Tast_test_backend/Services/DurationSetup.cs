using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeTestApp.Services
{
    public class DurationSetup
    {
        //Устновка времени
        public int MaxTime { get; }

        ///Конструктор
        public DurationSetup(int maxTime)
        {
            MaxTime = maxTime;
        }
    }
}
