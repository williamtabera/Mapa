using System;

namespace Location.ClassMaster
{
    public class CustomPin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime? FullyAttendedTime { get; set; }
    }
}