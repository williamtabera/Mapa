using System;
using System.Collections.Generic;
using System.Text;

namespace Location.ClassMaster
{
    class location
    {
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
