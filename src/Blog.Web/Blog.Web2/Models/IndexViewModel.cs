using System;
using System.ComponentModel.DataAnnotations; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web2.Models
{
    public class IndexViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]

        public string Titolo { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public DateTime Periodo { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Contenuto { get; set; }
        public string Consigliato { get; set; }
        public string Sconsigliato { get; set; }
    }
}
