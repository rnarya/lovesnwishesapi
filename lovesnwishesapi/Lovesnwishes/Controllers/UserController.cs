using Lovesnwishes.BusniessLogic;
using Lovesnwishes.DataBase;
using Lovesnwishes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lovesnwishes.Controllers
{
    public class UserController : ApiController
    {
        UserService objUserService = new UserService();
        public UserController()
        {
        }

        public string Get()
        {
            return "ss";
        }
        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var result=objUserService.GetUserProfile(id);
            if (result != null)
            {
                return Ok<APIResponse>(new APIResponse(true, result, "User profile fecthed sucessfully."));
            }
            else
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, new APIResponse(false, result, "User profile not found.")));
            }
           
        }

        // POST api/<controller>
        public IHttpActionResult Post(RequestUser request)
        {
            UserResponse objResponse = new UserResponse();
            try
            {
                objResponse = objUserService.Registration(request);
                if(objResponse != null && objResponse.UserId>0)
                {
                    return Ok<APIResponse>(new APIResponse(true, objResponse, "User registered successfully."));
                }
                else if(objResponse.UserId==0)
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, new APIResponse(false, objResponse, "Email already exists in the event.")));
                }
                else
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.ExpectationFailed, objResponse));
                }
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, new APIResponse(false, objResponse, "Unexpected error occured.")));
            }
            
        }


        // POST api/<controller>
        [Route("api/user/login")]
        public IHttpActionResult Login(Login request)
        {
            try
            {
                var objResponse = objUserService.Login(request);
                if (objResponse != null && objResponse.UserId > 0)
                {
                    return Ok<APIResponse>(new APIResponse(true, objResponse, "User logged in successfully."));
                }
                else 
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, new APIResponse(false, objResponse, "Wrong credentials.")));
                }
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, new APIResponse(false, null, "Unexpected error occured.")));
            }

        }

        [HttpPost]
        [Route("api/user/ChangePassword")]
        // PUT api/<controller>/5
        public IHttpActionResult ChangePassword(RequestUser request)
        {
            UserResponse objResponse = new UserResponse();
            try
            {
                objResponse = objUserService.ChangePassword(request);
                if (objResponse != null && objResponse.UserId > 0)
                {
                    return Ok<APIResponse>(new APIResponse(true, objResponse, "Password updated successfully."));
                }
                else if (objResponse.UserId == 0)
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, new APIResponse(false, objResponse, "Password updated failed.")));
                }
                else
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.ExpectationFailed, objResponse));
                }
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, new APIResponse(false, objResponse, "Unexpected error occured.")));
            }

        }


        [HttpPost]
        [Route("api/user/UpdateProfile")]
        // PUT api/<controller>/5
        public IHttpActionResult UpdateProfile(RequestUser request)
        {
            UserResponse objResponse = new UserResponse();
            try
            {
                objResponse = objUserService.UpdateProfile(request);
                if (objResponse != null && objResponse.UserId > 0)
                {
                    return Ok<APIResponse>(new APIResponse(true, objResponse, "Profile updated successfully."));
                }
                else if (objResponse.UserId == 0)
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, new APIResponse(false, objResponse, "Password update failed.")));
                }
                else
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.ExpectationFailed, objResponse));
                }
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, new APIResponse(false, objResponse, "Unexpected error occured.")));
            }

        }

        [HttpPost]
        [Route("api/user/UpdateProfileImage")]
        // PUT api/<controller>/5
        public IHttpActionResult UpdateProfileImage(ProfileImage request)
        {
            UserResponse objResponse = new UserResponse();
            try
            {
                objResponse = objUserService.UpdateProfileImage(request);
                if (objResponse != null && objResponse.UserId > 0)
                {
                    return Ok<APIResponse>(new APIResponse(true, objResponse, "Profile picture successfully."));
                }
                else if (objResponse.UserId == 0)
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, new APIResponse(false, objResponse, "Password  picture update failed.")));
                }
                else
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.ExpectationFailed, objResponse));
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


        // POST api/<controller>
        [HttpPost]
        [Route("api/user/sendFriendrequest")]
        public IHttpActionResult SendFriendRequest(SendFriendReq request)
        {
            try
            {
                //var objResponse = objUserService.Login(request);
                if (true)
                {
                    return Ok<APIResponse>(new APIResponse(true, "", "Request sent successfully."));
                }
                //else
                //{
                //    return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, new APIResponse(false, objResponse, "Wrong credentials.")));
                //}
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, new APIResponse(false, null, "Unexpected error occured.")));
            }

        }


        // POST api/<controller>
        [HttpGet]
        [Route("api/user/GetFriendList/{id}")]
        public IHttpActionResult GetFriendList(int id)
        {
            List<GetFriendResponse> objFriendList = new List<GetFriendResponse>();
            try
            {
                objFriendList = new List<GetFriendResponse> { new GetFriendResponse { FirstName="Girjehs", LastName="Kushwaha",
                 Id=2, PhotoUrl=""} };
                //var objResponse = objUserService.Login(request);
                if (true)
                {
                    return Ok<APIResponse>(new APIResponse(true, objFriendList, "Request sent successfully."));
                }
                //else
                //{
                //    return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, new APIResponse(false, objResponse, "Wrong credentials.")));
                //}
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, new APIResponse(false, null, "Unexpected error occured.")));
            }

        }

    }
}