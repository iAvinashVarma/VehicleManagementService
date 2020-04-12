using MongoDB.Bson;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VehicleManagementSystemBusiness.Infrastructure.Factory;
using VehicleManagementSystemBusiness.Infrastructure.Interface;
using VehicleManagementSystemBusiness.Model;

namespace VehicleManagementSystemApi.Controllers
{
    /// <summary>
    /// Driver Api
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DriverController : ApiController
    {
        private readonly IDriverRepository<Driver> driverRepository = null;

        /// <summary>
        /// Dynamic Driver Instantiator
        /// </summary>
        public DriverController()
        {
            driverRepository = DriverFactory.Repository;
        }

        /// <summary>
        /// Get all Driver information.
        /// </summary>
        /// <returns>Driver</returns>
        // GET api/values
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage httpResponseMessage;
            var drivers = driverRepository.GetAll().ToList();
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, drivers);
            return httpResponseMessage;
        }

        /// <summary>
        /// Get Driver information.
        /// </summary>
        /// <param name="id">DriverId</param>
        /// <returns>Driver</returns>
        [Route("api/Driver/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            HttpResponseMessage httpResponseMessage;
            var driver = driverRepository.GetById(new ObjectId(id));
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, driver);
            return httpResponseMessage;
        }

        /// <summary>
        /// Get driver information based on name.
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Vehicle</returns>
        [HttpGet]
        public HttpResponseMessage GetByName(string name)
        {
            HttpResponseMessage httpResponseMessage;
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, driverRepository.GetEntitiesByName(name));
            return httpResponseMessage;
        }

        /// <summary>
        /// Get driver information based on identity.
        /// </summary>
        /// <param name="identity">Identity</param>
        /// <returns>Vehicle</returns>
        [HttpGet]
        public HttpResponseMessage GetByIdentity(string identity)
        {
            HttpResponseMessage httpResponseMessage;
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, driverRepository.GetEntityByIdentity(identity));
            return httpResponseMessage;
        }

        /// <summary>
        /// Create new driver.
        /// </summary>
        /// <param name="driver">Driver Information</param>
        /// <returns>Created driver</returns>
        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Driver driver)
        {
            HttpResponseMessage httpResponseMessage;
            driver.ModifiedDate = DateTime.Now;
            driver.CreatedDate = DateTime.Now;
            var addedDriver = driverRepository.Add(driver);
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.Created, addedDriver);
            httpResponseMessage.Headers.Location = new Uri($"{Request.RequestUri}/{addedDriver.Id}");
            return httpResponseMessage;
        }

        /// <summary>
        /// Update existing driver.
        /// </summary>
        /// <param name="id">Existing driver id</param>
        /// <param name="driver">Existing driver information</param>
        /// <returns>Updated vehicle</returns>
        [Route("api/Driver/{id}")]
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody] Driver driver)
        {
            driver.Id = new ObjectId(id);
            driver.ModifiedDate = DateTime.Now;
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.Created, driverRepository.Update(driver));
            httpResponseMessage.Headers.Location = new Uri($"{Request.RequestUri}/{driver.Id}");
            return httpResponseMessage;
        }

        /// <summary>
        /// Delete existing driver.
        /// </summary>
        /// <param name="id">Existing driver id</param>
        /// <returns>Deleted vehicle information</returns>
        [Route("api/Driver/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            HttpResponseMessage httpResponseMessage;
            var objectId = new ObjectId(id);
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.Accepted, driverRepository.Remove(objectId));
            return httpResponseMessage;
        }
    }
}
