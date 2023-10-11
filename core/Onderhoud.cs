using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht4.core
{
    [Table("Onderhoud")]
    internal class Onderhoud
    {
        public int OnderhoudID { get; set; }
        public int MedewerkerID { get; set; }
        public Medewerker coordinator { get; set; }
        public int AttractieID { get; set; }
        public Attractie Attractie { get; set; }
        public string Probleem { get; set; } = string.Empty;
        public DateTimeBereik _dtb { get; set; }
    }
}