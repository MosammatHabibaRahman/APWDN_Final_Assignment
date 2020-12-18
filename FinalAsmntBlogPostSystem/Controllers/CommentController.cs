using FinalAsmntBlogPostSystem.Models;
using FinalAsmntBlogPostSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalAsmntBlogPostSystem.Controllers
{
    [RoutePrefix("api/posts")]
    public class CommentController : ApiController
    {
        //PostRepository pr = new PostRepository();
        CommentRepository cr = new CommentRepository();

        [Route("{id}/comments")]
        public IHttpActionResult GetAll(int id)
        {
            return Ok(cr.GetAll());
        }

        [Route("{id}/comments/{cid:int}", Name = "GetCommentByPostId")]
        public IHttpActionResult Get(int cid)
        {
            var comment = cr.Get(cid);
            if (comment == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(cr.Get(cid));
        }

        [Route("{id}/comments")]
        public IHttpActionResult Post(Comment comment)
        {
            cr.Insert(comment);
            string uri = Url.Link("GetCommentByPostId", new { id = comment.CommentId });
            return Created(uri, comment);
        }

        [Route("{id}/comments/{commentId:int}")]
        public IHttpActionResult Delete(int id)
        {
            cr.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
