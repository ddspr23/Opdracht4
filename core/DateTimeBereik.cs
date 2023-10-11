using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht4.core
{
    [Owned]
    internal class DateTimeBereik
    {
        public DateTime Begin { get; set; } = DateTime.Now;
        public DateTime? End { get; set; } = DateTime.Now.AddHours(3);

        public bool Eindigt()
        {
            if (DateTime.Now == End)
                return true;

            return false;
        }

        public bool Overlapt(DateTimeBereik _that)
        {
            if (Begin == _that.Begin && End == _that.End)
                return true;

            return false;
        }
    }
}
