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
    public class FeedController : ApiController
    {
        FeedService objFeedService = new FeedService();
        // GET api/<controller>
        [Route("api/FeedList")]
        public IHttpActionResult GetFeedList(int userId)
        {
            var objResponse = objFeedService.GetFeedList(userId);
            if (objResponse != null && objResponse.Count>0)
            {
                return Ok<APIResponse>(new APIResponse(true, objResponse, "Feed list fetched sucessfully."));
            }
            else
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, new APIResponse(false, objResponse, "Feed not found.")));
            }
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var objResponse = objFeedService.GetFeed(id);
            if (objResponse != null)
            {
                return Ok<APIResponse>(new APIResponse(true, objResponse, "Feed fected sucessfully."));
            }
            else
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, new APIResponse(false, objResponse, "Feed not found.")));
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post(Feed request)
        {
            FeedReponse objResponse = new FeedReponse();
            try
            {
                objResponse = objFeedService.PostFeed(request);
                if(objResponse!=null && objResponse.Id>0)
                {
                    return Ok<APIResponse>(new APIResponse(true, objResponse, "Feed saved sucessfully."));
                }
                else
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, new APIResponse(false, objResponse, "Feed not found.")));
                }
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, new APIResponse(false, objResponse, "Unexpected error occured.")));
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}