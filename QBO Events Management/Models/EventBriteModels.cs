using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace QBO_Events_Management.Models
{
    public class EventBriteEvents
    {
        [JsonProperty("events")]
        public List<EventBriteEvent> Events { get; set; }
    }

    public class EventBriteEvent
    {
        [JsonProperty("id")]
        public String ID { get; set; }


        [JsonProperty("name")]
        public Name Names { get; set; }

        [JsonProperty("description")]
        public Description Descriptions { get; set; }

        [JsonProperty("start")]
        public Start Start { get; set; }

        [JsonProperty("end")]
        public End End { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("changed")]
        public DateTime Changed { get; set; }

        [JsonProperty("status")]
        public String Status { get; set; }
    }

    public class Name
    {
        [JsonProperty("text")]
        public String Text { get; set; }
    }

    public class Description
    {
        [JsonProperty("text")]
        public String Text { get; set; }
    }

    public class Start
    {
        [JsonProperty("utc")]
        public DateTime UTC { get; set; }
    }

    public class End
    {
        [JsonProperty("utc")]
        public DateTime UTC { get; set; }
    }
}