using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QBO_Events_Management.Models
{
    public class EventAttendees
    {
        [JsonProperty("attendees")]
        public List<EventAttendee> Attendees { get; set; }
    }

    public class EventAttendee
    {
        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("changed")]
        public DateTime Changed { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("profiles")]
        public Profile Profiles { get; set; }
    }

    public class Profile
    {
        [JsonProperty("first_name")]
        public String FirstName { get; set; }

        [JsonProperty("last_name")]
        public String LastName { get; set; }

        [JsonProperty("email")]
        public String Email { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }
    }
}