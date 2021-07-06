using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HunterMoviesData
{
    public class Actors
    {

        [Key]
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string BirthDay { get; set; }
        [Required]
        public string Sex { get; set; }
        public string Photo { get; set; }

        public ICollection<Movies> Movies { get; set; }
    }
}

