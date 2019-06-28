using System;
using System.Collections.Generic;
using System.Text;

namespace FaceFinder.Model
{
    public class PersonWanted
    {
        //This is the MODEL Of VIEW HOME PAGE
        public PersonWanted() { }

        public string Name { get; set; }
        public string NickName { get; set; }
        public int Age { get; set; }
        public string WantedReasons  { get; set; }
        public string PhotoUrl { get; set; }
    }
}
