using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcTowar
    {
        public int TowarID { get; set; }

        [Display(Name = "Nazwa towaru")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string nazwa { get; set; }

        [Display(Name = "Cena jedn.")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public Nullable<decimal> cena { get; set; }

        public virtual ICollection<mvcZamowienie> Zamowienie { get; set; }
    }
}