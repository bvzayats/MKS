namespace NedoNet.API.Common {
    public class OperationResult {
        private OperationResult( bool isSuccess, string errorMessage, object result ) {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            Result = result;
        }

        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public object Result { get; set; }

        public static OperationResult Success(object result = null) {
            return new OperationResult(isSuccess: true, errorMessage: null, result: result);
        }

        public static OperationResult Error( string errorMessage, object result = null ) {
            return new OperationResult(isSuccess: false, errorMessage: errorMessage, result: result);
        }
    }
}