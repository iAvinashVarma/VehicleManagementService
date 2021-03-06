﻿using MongoDB.Bson;
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
    /// Vehicle Api
    /// </summary>
    [Authorize(Roles = "admin")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VehicleController : ApiController
    {
        private readonly IVehicleRepository<Vehicle> vehicleRepository = null;

        /// <summary>
        /// Dynamic Vehicle Instantiator
        /// </summary>
        public VehicleController()
        {
            vehicleRepository = VehicleFactory.Repository;
        }

        /// <summary>
        /// Get all Vehicle information.
        /// </summary>
        /// <returns>Vehicle</returns>
        // GET api/values
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage httpResponseMessage;
            var vehicles = vehicleRepository.GetAll().ToList();
            httpResponseMessage = vehicles.Any() ? Request.CreateResponse(HttpStatusCode.OK, vehicles) : Request.CreateResponse(HttpStatusCode.NoContent);
            return httpResponseMessage;
        }

        /// <summary>
        /// Get Vehicle information.
        /// </summary>
        /// <param name="id">VehicleId</param>
        /// <returns>Vehicle</returns>
        [Route("api/Vehicle/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            HttpResponseMessage httpResponseMessage;
            var vehicle = vehicleRepository.GetById(new ObjectId(id));
            httpResponseMessage = vehicle != null ? Request.CreateResponse(HttpStatusCode.OK, vehicle) : Request.CreateResponse(HttpStatusCode.NoContent);
            return httpResponseMessage;
        }

        /// <summary>
        /// Get vehicle information based on name.
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Vehicle</returns>
        [HttpGet]
        public HttpResponseMessage GetByName(string name)
        {
            HttpResponseMessage httpResponseMessage;
            var vehicles = vehicleRepository.GetEntitiesByName(name);
            httpResponseMessage = vehicles.Any() ? Request.CreateResponse(HttpStatusCode.OK, vehicles) : Request.CreateResponse(HttpStatusCode.NoContent);
            return httpResponseMessage;
        }

        /// <summary>
        /// Get vehicle information based on RegistrationNumber.
        /// </summary>
        /// <param name="registrationNumber">RegistrationNumber</param>
        /// <returns>Vehicle</returns>
        [HttpGet]
        public HttpResponseMessage GetByRegistrationNumber(string registrationNumber)
        {
            HttpResponseMessage httpResponseMessage;
            var vehicle = vehicleRepository.GetEntityByRegistrationNumber(registrationNumber);
            httpResponseMessage = vehicle != null ? Request.CreateResponse(HttpStatusCode.OK, vehicle) : Request.CreateResponse(HttpStatusCode.NoContent);
            return httpResponseMessage;
        }

        /// <summary>
        /// Create new vehicle.
        /// </summary>
        /// <param name="vehicle">Vehicle Information</param>
        /// <returns>Created Vehicle</returns>
        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Vehicle vehicle)
        {
            HttpResponseMessage httpResponseMessage;
            vehicle.ModifiedDate = DateTime.Now;
            vehicle.CreatedDate = DateTime.Now;
            var addedVehicle = vehicleRepository.Add(vehicle);
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.Created, addedVehicle);
            httpResponseMessage.Headers.Location = new Uri($"{Request.RequestUri}/{addedVehicle.Id}");
            return httpResponseMessage;
        }

        /// <summary>
        /// Update existing vehicle.
        /// </summary>
        /// <param name="id">Existing vehicle id</param>
        /// <param name="vehicle">Existing vehicle information</param>
        /// <returns>Updated vehicle</returns>
        [Route("api/Vehicle/{id}")]
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody] Vehicle vehicle)
        {
            vehicle.Id = new ObjectId(id);
            vehicle.ModifiedDate = DateTime.Now;
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.Created, vehicleRepository.Update(vehicle));
            httpResponseMessage.Headers.Location = new Uri($"{Request.RequestUri}/{vehicle.Id}");
            return httpResponseMessage;
        }

        /// <summary>
        /// Delete existing vehicle.
        /// </summary>
        /// <param name="id">Existing vehicle id</param>
        /// <returns>Deleted vehicle information</returns>
        [Route("api/Vehicle/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            HttpResponseMessage httpResponseMessage;
            var objectId = new ObjectId(id);
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.Accepted, vehicleRepository.Remove(objectId));
            return httpResponseMessage;
        }
    }
}
