using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcVMFakturaKlient
    {
        public int FakturaID { get; set; }
        public string NrFaktury { get; set; }
        public Nullable<int> KlientID { get; set; }
        public Nullable<decimal> wartosc { get; set; }
        public Nullable<System.DateTime> Data { get; set; }

        public string nazwaKlienta { get; set; }
        public string numerKlienta { get; set; }
    }
}