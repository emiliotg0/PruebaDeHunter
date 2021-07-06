using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HunterMoviesData
{
    public class Movies
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [ForeignKey("Gender")]
        public Gender Gender { get; set; }
        [Required]
        public string ReleaseDate { get; set; }

        public string Photo { get; set; }
         public string IdActor { get; set; }

        public ICollection<Actors> Actors { get; set; }
    }

    public class Gender
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Genero { get; set; }
        public ICollection<Movies> Movies { get; set; }
    }
}
