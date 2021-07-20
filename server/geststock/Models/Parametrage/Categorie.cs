using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace geststock.Models.Parametrage
{
    public class Categorie
    {
        [Key]
        public int id { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
    }
}
