using MongoDB.Bson;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VehicleManagementSystemBusiness.Infrastructure.Factory;
using VehicleManagementSystemBusiness.Infrastructure.Interface;
using VehicleManagementSystemBusiness.Model;

namespace VehicleManagementSystemApi.Controllers
{
    /// <summary>
    /// Driver Messenger Api
    /// </summary>
    public class DriverMessengerController : ApiController
    {
        private readonly IVehicleRepository<Vehicle> vehicleRepository = null;
        private readonly IDriverRepository<Driver> driverRepository = null;
        private readonly IDriverMessengerRepository<DriverMessenger> driverMessengerRepository = null;

        /// <summary>
        /// Dynamic Vehicle Monitor Instantiator
        /// </summary>
        public DriverMessengerController()
        {
            vehicleRepository = VehicleFactory.Repository;
            driverRepository = DriverFactory.Repository;
            driverMessengerRepository = DriverMessengerFactory.Repository;
        }

        /// <summary>
        /// Get all Driver Messenger information.
        /// </summary>
        /// <returns>DriverMessenger</returns>
        // GET api/values
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage httpResponseMessage;
            var driverMessenger = driverMessengerRepository.GetAll().ToList();
            var filterDriverMessenger = driverMessenger.Select(m => new
            {
                Vehicle = vehicleRepository.GetById(m.VehicleId),
                Driver = driverRepository.GetById(m.DriverId),
                VehicleMonitor = m
            });
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, filterDriverMessenger);
            return httpResponseMessage;
        }

        /// <summary>
        /// Create new Driver message.
        /// </summary>
        /// <param name="driverMessenger">Driver Messenger Information</param>
        /// <returns>Created Driver Messenger</returns>
        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post([FromBody] DriverMessenger driverMessenger)
        {
            HttpResponseMessage httpResponseMessage;
            var addedDriverMessage = driverMessengerRepository.Add(driverMessenger);
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.Created, addedDriverMessage);
            httpResponseMessage.Headers.Location = new Uri($"{Request.RequestUri}/{addedDriverMessage.Id}");
            return httpResponseMessage;
        }

        /// <summary>
        /// Update existing Driver Message.
        /// </summary>
        /// <param name="id">Existing Driver Messenger id</param>
        /// <param name="driverMessenger">Existing DriverMessenger information</param>
        /// <returns>Updated DriverMessenger</returns>
        // PUT api/values/5
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody] DriverMessenger driverMessenger)
        {
            driverMessenger.Id = new ObjectId(id);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.Created, driverMessengerRepository.Update(driverMessenger));
            httpResponseMessage.Headers.Location = new Uri($"{Request.RequestUri}/{driverMessenger.Id}");
            return httpResponseMessage;
        }

        /// <summary>
        /// Delete existing Driver Message.
        /// </summary>
        /// <param name="id">Existing Driver Messenger id</param>
        /// <returns>Deleted Driver Messenger information</returns>
        // DELETE api/values/5
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            HttpResponseMessage httpResponseMessage;
            var objectId = new ObjectId(id);
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.Accepted, driverMessengerRepository.Remove(objectId));
            return httpResponseMessage;
        }
    }
}
