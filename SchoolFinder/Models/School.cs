using Windows.Devices.Geolocation;

namespace SchoolFinder.Models
{
    public class School
    {
        public string Name { get; set; }
        public float Rating { get; set; } = 1.0f;
        public string Address { get; set; }
        public Geopoint LatLon { get; set; }
        public string SchoolType { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }

    }
}
