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
            return Ok(cr.GetAllByPostId(id));
        }

        [Route("{id}/comments/{cid:int}", Name = "GetCommentByPostId")]
        public IHttpActionResult Get(int id, int cid)
        {
            var comment = cr.GetCommentOfAPost(id,cid);
            if (comment == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(cr.GetCommentOfAPost(id,cid));
        }

        [Route("{id}/comments")]
        public IHttpActionResult Post(Comment comment)
        {
            cr.Insert(comment);
            string uri = Url.Link("GetCommentByPostId", new { cid = comment.CommentId });
            return Created(uri, comment);
        }
        
        [Route("{id}/comments/{cid:int}")]
        public IHttpActionResult Put([FromUri] int cid, [FromBody] Comment comment)
        {
            comment.CommentId = cid;
            cr.Update(comment);
            return Ok(comment);
        }

        [Route("{id}/comments/{cid:int}")]
        public IHttpActionResult Delete(int cid)
        {
            cr.Delete(cid);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
