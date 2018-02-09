using System;
using System.Threading.Tasks;
using System.Threading;
using EasyBLEasy.Implementation;

namespace EasyBLEasy
{
    public class BLEDevice
    {
        private RequestManager RequestManager { get; set; }

        public IBLEImplementationDevice ImplementationDevice { get; set; }
        public Guid DeviceGuid { get; set; }
        public string DeviceName { get; set; }
        public bool IsConnected { get; set; }
        public bool IsActivelyConnected { get; set; }

        public Task DisconnectSoft()
        {
        }

        public Task DisconnectHard()
        {
        }

        public async Task<byte[]> WriteCharacteristicAndReadResponse(Guid service, Guid characteristic, byte[] data, CancellationToken t = default(CancellationToken))
        {
            var writetsk = WriteCharacteristic(service, characteristic, data);
            return await ReadCharacteristic(service, characteristic);
        }

        public async Task WriteCharacteristic(Guid service, Guid characteristic, byte[] data)
        {
            var op = new BLEOperation
            {
                OperationType = BLEOperationType.CharacteristicWrite,
                ServiceGuid = service,
                CharacteristicGuid = characteristic,
                DataIn = data
            };

            RequestManager.AddOperation(op);

            await op.CompletionSource.Task;
        }

        public async Task<byte[]> ReadCharacteristic(Guid service, Guid characteristic)
        {
            var op = new BLEOperation
            {
                OperationType = BLEOperationType.CharacteristicRead,
                ServiceGuid = service,
                CharacteristicGuid = characteristic,
            };

            RequestManager.AddOperation(op);
            await op.CompletionSource.Task;
            return op.DataOut;
        }

        public async Task<byte[]> GetCharacteristicValue(Guid service, Guid characteristic)
        {
            
        }
    }
}
