namespace CodeBase.Network.Services
{
    public class ConnectionResult
    {
        public bool IsSuccess { get; private set; }
        public bool IsFailure => !IsSuccess;
        
        public string Message { get; private set; }

        public static ConnectionResult Success() =>
            new()
            {
                IsSuccess = true
            };

        public static ConnectionResult Failure(string message = "") =>
            new ConnectionResult()
            {
                IsSuccess = false,
                Message = message
            };
    }
}