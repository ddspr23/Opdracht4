using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht4.core
{
    [Table("Gast")]
    internal class Gast : Gebruiker
    {
        public int Credits { get; set; } = 0;
        public DateTime GeboorteDatum { get; set; } = new DateTime(2001, 11, 9);
        public DateTime EersteBezoek { get; set; } = new DateTime(2001, 11, 9);

        public int AttractieID { get; set; }
        public Attractie Attractie { get; set; }

        public int? BegeleiderID { get; set; }
        public Gast? Begeleider { get; set; }

        public Gast(string Email)
            : base(Email)
        {
            //
        }
    }
}
