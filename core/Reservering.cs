using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht4.core
{
    [Table("Reservering")]
    internal class Reservering
    {
        public int ReserveringID { get; set; }
        public DateTimeBereik _dtb { get; set; }

        public int GastID { get; set; }
        public Gast _gast { get; set; }

        public int AttractieID { get; set; }
        public Attractie _attr { get; set; }
    }
}