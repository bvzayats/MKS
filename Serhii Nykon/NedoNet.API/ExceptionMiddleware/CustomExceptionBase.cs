using System;

namespace NedoNet.API.Exceptions {
    public class CustomExceptionBase : Exception {
        public int Code { get; set; }
        public object Body { get; set; }

        public CustomExceptionBase(string message, object body, int code) : base(message) {
            Code = code;
            Body = body;
        }
    }
}