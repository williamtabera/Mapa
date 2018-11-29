using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Location.Api.Models
{
    [Table("Localizacion")]
    public class tblLocalizacion
    {
        [Key]
        public int Id { get; set; }
        
        public string LocalDateTime { get; set; }
        
        public string Latitude { get; set; }
       
        public string Longitude { get; set; }
        
        public string Altitude { get; set; }
        
        public string AltitudeAccuracy { get; set; }

        public string Accuracy { get; set; }

        public string Heading { get; set; }

        public string Speed { get; set; }
    }
}