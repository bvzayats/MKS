using System;

namespace NedoNet.API.Models {
    public class UserViewModel {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
    }
}