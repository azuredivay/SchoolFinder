using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolFinder.Models
{
    public class Kid
    {
        public string Name { get; set; }
        public float Age { get; set; }
        public string SchoolType
        {
            get
            {
                if (Age < 6) return "Kindergarten";
                else if (Age < 10 && Age > 5) return "Elementry School";
                else if (Age < 14 && Age > 10) return "Middle School";
                else if (Age > 14) return "High School";
                else return "Some School";
            }
        }
        public float Budget { get; set; }
    }
}
