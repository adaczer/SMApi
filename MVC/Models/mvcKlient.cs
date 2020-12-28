using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcKlient
    {
        public int KlientID { get; set; }

        [Display(Name = "Nazwa Klienta")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string nazwaKlienta { get; set; }

        public string numerKlienta { get; set; }

        public virtual ICollection<mvcFaktura> Faktura { get; set; }
    }
}