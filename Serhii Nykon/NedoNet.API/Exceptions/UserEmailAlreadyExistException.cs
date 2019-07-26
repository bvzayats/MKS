using Microsoft.AspNetCore.Http;

namespace NedoNet.API.Exceptions {
    public class UserEmailAlreadyExistException : CustomExceptionBase {
        public UserEmailAlreadyExistException( string message, object body = null ) : base( message, body, StatusCodes.Status400BadRequest ) {
        }
    }
}