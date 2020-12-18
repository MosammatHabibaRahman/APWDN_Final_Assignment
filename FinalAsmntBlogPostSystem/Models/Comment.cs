using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalAsmntBlogPostSystem.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}