using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace EasyBLEasy.Implementation
{
    public interface IBLEImplementationDevice
    {
        Guid DeviceGuid { get; set; }
        string DeviceName { get; set; }
        void BeginBLEOperation(BLEOperation operation);
        List<Guid> GetDiscoveredServices();
        List<Guid> CharacteristicsForService(Guid service);
        byte[] GetCharacteristicValue(Guid service, Guid characteristic);
    }
}
