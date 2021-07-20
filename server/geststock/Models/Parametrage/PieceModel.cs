using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace geststock.Models.Parametrage
{
    public class PieceModel
    {
        [Key]
        public int IdPiece { get; set; }
        public string Code { get; set; }
        public string Libelle { get; set; }
    }
}
