using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalAsmntBlogPostSystem.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}