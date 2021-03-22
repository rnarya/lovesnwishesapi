using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lovesnwishes.Models
{

    public class Feed
    {
        //public int FeedType { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public string UniqueId { get; set; }

        public string mediaJson { get; set; }
        //public List<int> ShareTo { get; set; }
    }


    public class FeedReponse
    {
        public int Id { get; set; }
        public int FeedType { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public string UniqueId { get; set; }

        public List<CommentModel> CommentList { get; set; }
        public User UserDetail { get;set; }

        public string mediaJson { get; set; }
        // public bool IsPublished { get; set; }
        //public Dictionary<int,string> ShareTo { get; set; }
    }

    public class SendFriendReq
    {
        public int SendFrom { get; set; }
        public int SendTo { get; set; }
        public bool IsFriend { get; set; }
    }

    public class GetFriendResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
    }

}