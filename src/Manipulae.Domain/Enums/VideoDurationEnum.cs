using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Manipulae.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum VideoDurationEnum
    {
        [EnumMember(Value = "Short")]
        Short,
        [EnumMember(Value = "Medium")]
        Medium,
        [EnumMember(Value = "Long")]
        Long
    }
}
