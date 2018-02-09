using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyBLEasy.Implementation;
namespace EasyBLEasy.Droid.Implementation
{
    public class BLEImplementationDevice : IBLEImplementationDevice
    {
        public BLEImplementationDevice()
        {
        }

        public Guid DeviceGuid { get; set; }
        public string DeviceName { get; set; }

        public List<Guid> CharacteristicsForService(Guid service)
        {
            throw new NotImplementedException();
        }

        public byte[] GetCharacteristicValue(Guid service, Guid characteristic)
        {
            throw new NotImplementedException();
        }

        public List<Guid> GetDiscoveredServices()
        {
            throw new NotImplementedException();
        }

        public Task RunBLEOperation(BLEOperation operation)
        {
            throw new NotImplementedException();
        }
    }
}
