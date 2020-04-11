using System.IO;
using VehicleManagementSystemBusiness.Infrastructure.Base;

namespace VehicleManagementSystemBusiness.Concrete.Utils
{
    public class FileProcess : SingletonBase<FileProcess>
    {
        private FileProcess() { }

        public string ReadAllText(string absoluteConnectionString)
        {
            return File.ReadAllText(absoluteConnectionString);
        }

        public void WriteAllText(string absoluteConnectionString, string serialize)
        {
            File.WriteAllText(absoluteConnectionString, serialize);
        }
    }
}
