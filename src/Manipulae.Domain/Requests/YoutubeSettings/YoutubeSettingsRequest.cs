using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Domain.Requests.YoutubeSettings
{
    public class YoutubeSettingsRequest
    {
        public string ApiKey { get; set; } = string.Empty;
        public string BasedUrl { get; set; } = string.Empty;
        public int MaxResults { get; set; }
        public string RegionCode { get; set; } = string.Empty;
        public string Theme { get; set; } = string.Empty;
        public int PublishedAt { get; set; }
    }
}
