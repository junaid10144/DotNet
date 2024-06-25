using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Identity.Api.Requests
{
    public class TokenGenerationRequest
    {
        public string Email { get; set; }
        public Guid UserId { get; set; }
        public Dictionary<string, object> CustomClaims { get; set; } = new Dictionary<string, object>();
    }
}
