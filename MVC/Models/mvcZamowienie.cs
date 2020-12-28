using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcZamowienie
    {
        public int ZamowienieID { get; set; }
        public Nullable<int> TowarID { get; set; }
        [Display(Name = "Cena")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public Nullable<decimal> Cena { get; set; }
        [Display(Name = "Ilość")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public Nullable<int> ilosc { get; set; }

        [Display(Name = "Rabat")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        [Range(0,100, ErrorMessage = "Rabat musi być liczbą od 0 do 100")]
        public Nullable<int> rabat { get; set; }

        [Display(Name = "Cena po rabacie")]
        public Nullable<decimal> PoRabacie { get; set; }

        [Display(Name = "Razem")]
        public Nullable<decimal> Razem { get; set; }
        public Nullable<int> FakturaID { get; set; }

        public virtual mvcFaktura Faktura { get; set; }
        public virtual mvcTowar Towar { get; set; }
        public virtual mvcKlient Klient { get; set; }
    }
}