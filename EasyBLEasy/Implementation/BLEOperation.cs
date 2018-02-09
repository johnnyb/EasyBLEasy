using System;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBLEasy.Implementation
{
    public enum BLEOperationType
    {
        CharacteristicWrite,
        CharacteristicRead,
        DescriptorWrite,
        DescriptorRead,
        NotificationActivationRequest,
        IndicationActivationRequest,
    }
    public enum BLEOperationStatus
    {
        Completed,
        Failed,
        Pending,
        Active
    }
    public class BLEOperation
    {
        public BLEOperationStatus OperationStatus { get; set; } = BLEOperationStatus.Pending;
        public CancellationToken CancellationToken { get; set; } = default(CancellationToken);
        public Guid ServiceGuid { get; set; }
        public Guid CharacteristicGuid { get; set; }
        public byte[] DataIn { get; set; }
        public byte[] DataOut { get; set; }
        public BLEOperationType OperationType { get; set; }
        public TaskCompletionSource<BLEOperationType> CompletionSource { get; set; } = new TaskCompletionSource<BLEOperationType>();
        public bool IsDone { get { return OperationStatus == BLEOperationStatus.Failed || OperationStatus == BLEOperationStatus.Completed; } }
    }
}
