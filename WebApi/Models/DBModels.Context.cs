﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SMAPIEntities : DbContext
    {
        public SMAPIEntities()
            : base("name=SMAPIEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Faktura> Faktura { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Towar> Towar { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }
    }
}
