﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusicDatabase
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MusicDatabaseEntities : DbContext
    {
        public MusicDatabaseEntities()
            : base("name=MusicDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cd> cdt { get; set; }
        public virtual DbSet<cd_esittaja> cd_esittajat { get; set; }
        public virtual DbSet<cd_kappale> cd_kappaleet { get; set; }
        public virtual DbSet<esittaja> esittajat { get; set; }
        public virtual DbSet<genre> genret { get; set; }
        public virtual DbSet<kappale> kappaleet { get; set; }
        public virtual DbSet<kappale_genre> kappale_genret { get; set; }
        public virtual DbSet<maa> maat { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<vuosi> vuodet { get; set; }
        public virtual DbSet<yhtio> yhtiot { get; set; }
    }
}
