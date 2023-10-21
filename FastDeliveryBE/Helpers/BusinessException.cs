namespace FastDeliveryBE.Helpers
{
    public class BusinessException:Exception
    {
        public Exception InnerException { get; }
        public string ErrorCode { get; }
        public string Message { get; }
        public string TypeName { get; }
        public string OperationName { get; }
        public Dictionary<string, object> ErrorDescriptors { get; }
        public bool WriteToLog { get; }

        public BusinessException(Exception innerException, string errorCode, string message, string typeName, string operationName,
          Dictionary<string, object> errorDescriptors, bool writeToLog = true)
            : base()
        {
            InnerException = innerException;
            ErrorCode = errorCode;
            Message = message;
            TypeName = typeName;
            OperationName = operationName;
            ErrorDescriptors = errorDescriptors;
            WriteToLog = writeToLog;
        }

       
    }
}
