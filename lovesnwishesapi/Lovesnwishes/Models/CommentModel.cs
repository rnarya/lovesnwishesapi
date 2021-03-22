using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lovesnwishes.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public int FeedId { get; set; }
        public string Comment { get; set; }
        public int CommentedBy { get; set; }

        public User UserDetail { get; set; }
    }
}