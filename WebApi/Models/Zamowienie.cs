//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zamowienie
    {
        public int ZamowienieID { get; set; }
        public Nullable<int> TowarID { get; set; }
        public Nullable<decimal> Cena { get; set; }
        public Nullable<int> ilosc { get; set; }
        public Nullable<int> rabat { get; set; }
        public Nullable<decimal> PoRabacie { get; set; }
        public Nullable<decimal> Razem { get; set; }
        public Nullable<int> FakturaID { get; set; }
        public Nullable<int> KlientID { get; set; }
    
        public virtual Faktura Faktura { get; set; }
        public virtual Towar Towar { get; set; }
        public virtual Klient Klient { get; set; }
    }
}
