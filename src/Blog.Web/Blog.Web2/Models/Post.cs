﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web2.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Titolo { get; set; }

        [DataType(DataType.Date)]
        public DateTime Periodo { get; set; }

        public string Contenuto { get; set; }
    }
}
