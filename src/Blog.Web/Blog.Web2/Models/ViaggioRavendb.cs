using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Blog.Web2.Models
{
    public class ViaggioRavendb
    {

             public string Id { get; set; }

             [Required(ErrorMessage = "Il campo è obbligatorio")]
            public string Citta { get; set; }
          

            [DataType(DataType.Date)]
            [Required(ErrorMessage = "Il campo è obbligatorio")]
            public DateTime Periodo { get; set; }
            [Required(ErrorMessage = "Il campo è obbligatorio")]
            public string Descrizione { get; set; }
            
            public string Consigliato { get; set; }
            public string Sconsigliato { get; set; }
        

    }

    public static partial class Extensions
    {
        /// <summary>
        ///     Converts a string that has been encoded for transmission in a URL into a decoded string.
        /// </summary>
        /// <param name="str">The string to decode.</param>
        /// <returns>A decoded string.</returns>
        public static String UrlDecode(this String str)
        {
            return HttpUtility.UrlDecode(str);
        }

        /// <summary>
        ///     Converts a URL-encoded string into a decoded string, using the specified encoding object.
        /// </summary>
        /// <param name="str">The string to decode.</param>
        /// <param name="e">The  that specifies the decoding scheme.</param>
        /// <returns>A decoded string.</returns>
        public static String UrlDecode(this String str, Encoding e)
        {
            return HttpUtility.UrlDecode(str, e);
        }
    }


   
  

}
