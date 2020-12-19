using FinalAsmntBlogPostSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalAsmntBlogPostSystem.Repositories
{
    public class CommentRepository:Repository<Comment>
    {
        public List<Comment> GetAllByPostId(int id)
        {
            return this.GetAll().Where(x => x.PostId == id).ToList();
        }

        public Comment GetCommentOfAPost(int id, int cid)
        {
            return this.GetAllByPostId(id).Where(x => x.CommentId == cid).FirstOrDefault();
        }
    }
}