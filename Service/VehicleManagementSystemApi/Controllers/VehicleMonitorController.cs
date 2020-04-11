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
    /// Vehicle Monitor Api
    /// </summary>
    public class VehicleMonitorController : ApiController
    {
        private readonly IVehicleRepository<Vehicle> vehicleRepository = null;
        private readonly IDriverRepository<Driver> driverRepository = null;
        private readonly IVehicleMonitorRepository<VehicleMonitor> vehicleMonitorRepository = null;

        /// <summary>
        /// Dynamic Vehicle Monitor Instantiator
        /// </summary>
        public VehicleMonitorController()
        {
            vehicleRepository = VehicleFactory.Repository;
            driverRepository = DriverFactory.Repository;
            vehicleMonitorRepository = VehicleMonitorFactory.Repository;
        }

        /// <summary>
        /// Get all Vehicle Monitor information.
        /// </summary>
        /// <returns>VehicleMonitor</returns>
        // GET api/values
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage httpResponseMessage;
            var vehicleMonitors = vehicleMonitorRepository.GetAll().ToList();
            var filtervehicleMonitors = vehicleMonitors.Select(m => new
            {
                Vehicle = vehicleRepository.GetById(m.VehicleId),
                Driver = driverRepository.GetById(m.DriverId),
                VehicleMonitor = m
            });
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, filtervehicleMonitors);
            return httpResponseMessage;
        }

        /// <summary>
        /// Create new vehicle monitor.
        /// </summary>
        /// <param name="vehicleMonitor">Vehicle monitor Information</param>
        /// <returns>Created Vehicle monitor</returns>
        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post([FromBody] VehicleMonitor vehicleMonitor)
        {
            HttpResponseMessage httpResponseMessage;
            var addedVehicleMonitor = vehicleMonitorRepository.Add(vehicleMonitor);
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.Created, addedVehicleMonitor);
            httpResponseMessage.Headers.Location = new Uri($"{Request.RequestUri}/{addedVehicleMonitor.Id}");
            return httpResponseMessage;
        }

        /// <summary>
        /// Update existing vehicle monitor.
        /// </summary>
        /// <param name="id">Existing vehicle monitor id</param>
        /// <param name="vehicleMonitor">Existing vehicle monitor information</param>
        /// <returns>Updated vehicle monitor</returns>
        // PUT api/values/5
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody] VehicleMonitor vehicleMonitor)
        {
            vehicleMonitor.Id = new ObjectId(id);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.Created, vehicleMonitorRepository.Update(vehicleMonitor));
            httpResponseMessage.Headers.Location = new Uri($"{Request.RequestUri}/{vehicleMonitor.Id}");
            return httpResponseMessage;
        }

        /// <summary>
        /// Delete existing vehicle monitor.
        /// </summary>
        /// <param name="id">Existing vehicle monitor id</param>
        /// <returns>Deleted vehicle monitor information</returns>
        // DELETE api/values/5
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            HttpResponseMessage httpResponseMessage;
            var objectId = new ObjectId(id);
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.Accepted, vehicleMonitorRepository.Remove(objectId));
            return httpResponseMessage;
        }
    }
}
