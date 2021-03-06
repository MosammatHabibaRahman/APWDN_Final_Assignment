﻿using FinalAsmntBlogPostSystem.Models;
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
        
        [Route("{id}", Name = "GetPostById")]
        public IHttpActionResult Get(int id)
        {
            var post = pr.Get(id);
            if (post == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(pr.Get(id));
        }

        [Route("")]
        public IHttpActionResult Post(Post post)
        {
            if(post.Text==null)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
            else
            {
                pr.Insert(post);
                string uri = Url.Link("GetPostById", new { id = post.PostId });
                return Created(uri, post);
            }
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromUri]int id,[FromBody]Post post)
        {
            if (post.Text == null)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
            else
            {
                post.PostId = id;
                pr.Update(post);
                return Ok(post);
            }
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            pr.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
