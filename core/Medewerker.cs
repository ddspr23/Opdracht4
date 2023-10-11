using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht4.core
{
    [Table("Medewerker")]
    internal class Medewerker : Gebruiker
    {
        public Medewerker(string Email)
            : base(Email)
        {
            //
        }
    }
}