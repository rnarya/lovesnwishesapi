using Lovesnwishes.BusniessLogic;
using Lovesnwishes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lovesnwishes.Controllers
{
    public class CommentController : ApiController
    {
        CommentService objCommentService = new CommentService();
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [Route("api/feed/comment")]
        public IHttpActionResult Post(CommentModel request)
        {
            CommentModel objResponse = new CommentModel();
            try
            {
                objResponse = objCommentService.PostComment(request);
                if (objResponse != null && objResponse.Id > 0)
                {
                    return Ok<APIResponse>(new APIResponse(true, objResponse, "Comment saved sucessfully."));
                }
                else
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, new APIResponse(false, objResponse, " Comment not posted.")));
                }
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, new APIResponse(false, objResponse, "Unexpected error occured.")));
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}