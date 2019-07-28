using Microsoft.AspNetCore.Http;

namespace NedoNet.API.Exceptions {
    public class ItemNotFoundException : CustomExceptionBase {
        public ItemNotFoundException( string message, object body = null) : base( message, body, StatusCodes.Status404NotFound ) {
        }
    }
}