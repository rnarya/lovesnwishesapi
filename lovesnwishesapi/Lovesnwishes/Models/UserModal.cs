using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lovesnwishes.Models
{
    public class RequestUser
    {
        public RequestUser()
        {
            this.Id = 0;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.PhotoUrl = "";
            this.MobileNo = "";
            this.Password = "";
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }

    }

    public class ResponseUser
    {
        public ResponseUser()
        {
            this.UserId = 0;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.UserName = "";
            this.PhotoUrl = "";
            this.isActive = true;
            this.MobileNo = "";
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhotoUrl { get; set; }
        public string MobileNo { get; set; }
        public bool isActive { get; set; }

    }

    public class UserResponse 
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class ProfileImage
    {
        public int id { get; set; }
        public string profilepicurl { get; set; }
    }

}