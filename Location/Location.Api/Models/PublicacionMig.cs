using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Location.Api.Models
{
    public class PublicacionMig: DbContext
    {
        public PublicacionMig() : base("PlublicacionConnection")
        {

        }

        public DbSet<tblLogin> Login { get; set; }
        public DbSet<tblLocalizacion> Localizacion { get; set; }
    }
}