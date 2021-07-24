using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommentProject.Models
{
    public class Comment
    {

        public int ID { get; set; }
        public int RosterKey { get; set; }
        public string Name { get; set; }
        public string TimeStamp {get; set;}
        public string CommentData { get; set; }

    }

    public class CommentObj
    {
        public List<Comment> Data { get; set; }
        public string NewComment { get; set; }
    }
}

