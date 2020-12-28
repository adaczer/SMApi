using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcFaktura
    {
        public int FakturaID { get; set; }
        public string NrFaktury { get; set; }
        public Nullable<int> KlientID { get; set; }
        public Nullable<decimal> wartosc { get; set; }
        [Display(Name = "Data faktury")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public Nullable<System.DateTime> Data { get; set; }

        public virtual mvcKlient Klient { get; set; }
        public virtual ICollection<mvcZamowienie> Zamowienie { get; set; }
    }
}