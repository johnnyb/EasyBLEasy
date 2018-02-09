using System;
using System.Collections.Generic;
namespace EasyBLEasy.Implementation
{
    public class RequestManager
    {
        public IBLEImplementationDevice ImplementationDevice { get; set; }

        public BLEOperation CurrentOperation { get; set; }

        private List<BLEOperation> OperationQueue { get; set; } = new List<BLEOperation>();

        public void AddOperation(BLEOperation op)
        {
            lock (OperationQueue)
            {
                OperationQueue.Add(op);
            }
            RunNextAvailableOperation();
        }

        public void RunNextAvailableOperation()
        {
            lock (OperationQueue)
            {
                if (CurrentOperation != null)
                {
                    if (!CurrentOperation.IsDone)
                    {
                        return; // Still processing
                    }
                }
                if (OperationQueue.Count > 0)
                {
                    var op = OperationQueue[0];
                    OperationQueue.RemoveAt(0);
                    op.OperationStatus = BLEOperationStatus.Active;
                    CurrentOperation = op;
                }
            }
            ImplementationDevice.BeginBLEOperation(CurrentOperation);
        }

        public RequestManager()
        {
        }
    }
}
