using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht4.core
{
    [Table("Gebruiker")]
    internal class Gebruiker
    {
        public int ID { get; set; }
        public string Email { get; set; } = string.Empty;

        public Gebruiker(string Email)
        {
            this.Email = Email;
        }
    }
}
