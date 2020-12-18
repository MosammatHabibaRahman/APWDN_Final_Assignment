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
    public class PostController : ApiController
    {
        PostRepository pr = new PostRepository();
        
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(pr.GetAll());
        }
    }
}
