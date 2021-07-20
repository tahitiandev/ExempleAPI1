using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace geststock.Models.Parametrage
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        public string Intitule { get; set; }
    }
}
