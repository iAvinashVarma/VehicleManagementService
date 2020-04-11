using System;

namespace VehicleManagementSystemBusiness.Custom.CustomException
{
    public class MongoCredentialException : Exception
    {
        public MongoCredentialException() : base($"Invalid credentials.")
        {

        }

        public MongoCredentialException(string message) : base(message)
        {

        }
    }
}
