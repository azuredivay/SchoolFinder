using SchoolFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace SchoolFinder.Services
{
    public static class MockServer
    {
        public static List<School> GetSchools()
        {
            return new List<School>
            {
                new School
                {
                    Name = "Little Kids",
                    Rating = 3.5f,
                    Address = "718 Rochford St",
                    LatLon = new Geopoint(new BasicGeoposition { Latitude = 41.872669, Longitude = -87.650915 }),
                    Phone = "555-555-555-5",
                    SchoolType = "Elementary School",
                    Website = "https://littlekidsschool.com"
                },
                new School
                {
                    Name = "Bigger Kids",
                    Rating = 4.5f,
                    Address = "728 Rochford St",
                    LatLon = new Geopoint(new BasicGeoposition { Latitude = 41.868404, Longitude = -87.652548 }),
                    Phone = "555-565-666-5",
                    SchoolType = "Middle School",
                    Website = "https://middlekidsschool.com"
                },
                new School
                {
                    Name = "Better Little Kids",
                    Rating = 2.0f,
                    Address = "798 Clinton St",
                    LatLon = new Geopoint(new BasicGeoposition { Latitude = 41.869885, Longitude = -87.6293 }),
                    Phone = "555-595-555-5",
                    SchoolType = "Elementary School",
                    Website = "https://betterlittlekidsschool.com"
                }
            };
        }

        public static List<string> GetSchoolNames()
        {
            return new List<string>
            {
                "Little Kids", "Bigger Kids", "Better Little Kids"
            };
        }
    }
}
