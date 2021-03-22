using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Lovesnwishes.BusniessLogic
{
    public class CustomActionResult<T>
    {
        HttpStatusCode _httpStatusCode;
        T _value;
        string _message;

        public CustomActionResult(HttpStatusCode httpStatusCode, T value, string message) 
        {
            _httpStatusCode = httpStatusCode;
            _value = value;
            _message = message;
        }
        //public IHttpActionResult ExecuteAsync()
        //{
        //    var response = new CustomActionResult<T>()
        //    {
        //        StatusCode = _httpStatusCode,
        //        RequestMessage = _request,
        //        Content = new ObjectContent(typeof(T), _value, new JsonMediaTypeFormatter())
        //    };
        //    return Task.FromResult(response);
        //}

    }

    public class APIResponse
    {
        public APIResponse(bool _IsSuccess, object _Data, string _Message = "")
        {
            IsSuccess = _IsSuccess;
            Data = _Data;
            //Remark = _Remark;
            Message = _Message;

        }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is success.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is success; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccess { get; set; } = false;

        /// <summary>
        /// Actual response if succeed 
        /// </summary>
        /// <value>
        /// Actual response if succeed 
        /// </value>
        public object Data { get; set; } = null;

        /// <summary>
        /// Remark if anythig to convey
        /// </summary>
        /// <value>
        /// Remark if anythig to convey
        /// </value>
       // public  Remark { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public object Message { get; set; } = null;


    }


}