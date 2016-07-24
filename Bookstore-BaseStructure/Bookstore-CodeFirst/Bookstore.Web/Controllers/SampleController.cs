namespace Bookstore.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web.Http;

    public class SampleUser
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }

    public class SampleController : ApiController
    {
        /// <summary>
        /// GET
        /// api/Sample
        /// Sample action to demonstrate GET method without authentication
        /// and the return type IHttpActionResult
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult GetWithoutAuth()
        {
            // Cannot be returned directly as a result - serialize exception
            // It needs to be as a property value of an anonymous object
            // Cannot be displayed as xml
            //var result = new[]
            //{
            //    new
            //    {
            //        Id = 1,
            //        Name = "Peter",
            //        Email = "peter@abv.bg"
            //    },
            //    new
            //    {
            //        Id = 1,
            //        Name = "Peter",
            //        Email = "peter@abv.bg"
            //    },
            //    new
            //    {
            //        Id = 1,
            //        Name = "Peter",
            //        Email = "peter@abv.bg"
            //    }
            //};


            // Can be represented as xml
            // Can be retrurned just as it as
            var result = new[]
            {
                new SampleUser()
                {
                    Id = 1,
                    Name = "Peter",
                    Email = "peter@abv.bg"
                },
                new SampleUser()
                {
                    Id = 1,
                    Name = "Peter",
                    Email = "peter@abv.bg"
                },
                new SampleUser()
                {
                    Id = 1,
                    Name = "Peter",
                    Email = "peter@abv.bg"
                }
            };

            //return this.Ok(new  { Result = result });

            return this.Ok(result);
        }


        /// <summary>
        /// GET
        /// api/sample/auth
        /// Sample action to demonstrate GET method with authentication
        /// and the return type HttpResponseMessage
        /// </summary>
        /// <returns>HttpResponseMessage</returns>
        [HttpGet]
        [Authorize]
        [Route("auth")] // Custom action name to avoid name conflicts
        public HttpResponseMessage GetWithAuthentication()
        {
            var result = new[]
            {
                new SampleUser()
                {
                    Id = 1,
                    Name = "Peter",
                    Email = "peter@abv.bg"
                },
                new SampleUser()
                {
                    Id = 1,
                    Name = "Peter",
                    Email = "peter@abv.bg"
                },
                new SampleUser()
                {
                    Id = 1,
                    Name = "Peter",
                    Email = "peter@abv.bg"
                }
            };

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(20)
            };

            return response;
        }

        /// <summary>
        /// POST
        /// api/sample
        /// Sample action to demonstrate POST method and the return type IEnumerable
        /// </summary>
        /// <returns>IEnumerable<SampleUser></returns>
        // [HttpPost] The action can be accessed without the attribute,
        // just by the name starting with Post
        public IEnumerable<SampleUser> PostSampleController()
        {
            var result = new[]
            {
                new SampleUser()
                {
                    Id = 1,
                    Name = "Peter",
                    Email = "peter@abv.bg"
                },
                new SampleUser()
                {
                    Id = 1,
                    Name = "Peter",
                    Email = "peter@abv.bg"
                },
                new SampleUser()
                {
                    Id = 1,
                    Name = "Peter",
                    Email = "peter@abv.bg"
                }
            };

            return result;
        } 

    }
}