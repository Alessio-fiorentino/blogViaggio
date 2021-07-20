using System;
using System.ComponentModel.DataAnnotations; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web2.Models
{
    public class IndexViewModel
    {
        public string Citta { get; set; }

        [DataType(DataType.Date)]
        public DateTime Periodo { get; set; }
        public string Descrizione { get; set; }

    }
}
