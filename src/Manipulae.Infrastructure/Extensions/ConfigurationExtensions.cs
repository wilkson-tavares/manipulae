using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Infrastructure.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string? GetYouTubeApiKey(this IConfiguration configuration)
        {
            return configuration["YouTubeApiKey"];
        }


    }
}
