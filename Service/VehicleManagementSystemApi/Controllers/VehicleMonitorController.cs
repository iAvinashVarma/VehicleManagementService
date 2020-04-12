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
    /// Vehicle Monitor Api
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
                _id = m.Id,
                vehicle = vehicleRepository.GetById(m.VehicleId),
                driver = driverRepository.GetById(m.DriverId),
                vehicleMonitor = m
            });
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, filtervehicleMonitors);
            return httpResponseMessage;
        }

        /// <summary>
        /// Get VehicleMonitor information.
        /// </summary>
        /// <param name="id">VehicleMonitor Id</param>
        /// <returns>VehicleMonitor</returns>
        [Route("api/VehicleMonitor/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            HttpResponseMessage httpResponseMessage;
            var vehicleMonitor = vehicleMonitorRepository.GetById(new ObjectId(id));
            var filterVehicleMonitor = new
            {
                _id = vehicleMonitor.Id,
                vehicle = vehicleRepository.GetById(vehicleMonitor.VehicleId),
                driver = driverRepository.GetById(vehicleMonitor.DriverId),
                vehicleMonitor = vehicleMonitor
            };
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, filterVehicleMonitor);
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
            vehicleMonitor.ModifiedDate = DateTime.Now;
            vehicleMonitor.CreatedDate = DateTime.Now;
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
        [Route("api/VehicleMonitor/{id}")]
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody] VehicleMonitor vehicleMonitor)
        {
            vehicleMonitor.Id = new ObjectId(id);
            vehicleMonitor.ModifiedDate = DateTime.Now;
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.Created, vehicleMonitorRepository.Update(vehicleMonitor));
            httpResponseMessage.Headers.Location = new Uri($"{Request.RequestUri}/{vehicleMonitor.Id}");
            return httpResponseMessage;
        }

        /// <summary>
        /// Delete existing vehicle monitor.
        /// </summary>
        /// <param name="id">Existing vehicle monitor id</param>
        /// <returns>Deleted vehicle monitor information</returns>
        [Route("api/VehicleMonitor/{id}")]
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
