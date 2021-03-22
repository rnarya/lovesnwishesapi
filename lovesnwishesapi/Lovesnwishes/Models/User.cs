using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lovesnwishes.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Password { get; set; }
        public string mobileNo { get; set; }
    }
}