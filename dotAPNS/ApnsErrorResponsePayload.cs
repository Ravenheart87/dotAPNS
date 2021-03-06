﻿using System;
using Newtonsoft.Json;

namespace dotAPNS
{
    public class ApnsErrorResponsePayload
    {
        [JsonIgnore]
        public ApnsResponseReason Reason => 
            Enum.TryParse<ApnsResponseReason>(ReasonRaw, out var value)
            ? value : ApnsResponseReason.Unknown;

        [JsonProperty("reason")]
        public string ReasonRaw { get; set; }

        [JsonConverter(typeof(UnixTimestampMillisecondsJsonConverter))] // timestamp is in milliseconds (https://openradar.appspot.com/24548417)
        public DateTimeOffset? Timestamp { get; set; }
    }
}