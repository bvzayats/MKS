using System;

namespace NedoNet.API.Exceptions {
    public class ItemNotFoundException : Exception {
        public ItemNotFoundException(string message, Guid id) : base(message) {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}