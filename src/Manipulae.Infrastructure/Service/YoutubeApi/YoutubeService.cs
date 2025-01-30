using Manipulae.Domain.Responses.Video;
using Manipulae.Domain.Requests.YoutubeSettings;
using Manipulae.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Manipulae.Domain.Interface.Service.YoutubeApi;
using Microsoft.Extensions.Options;
using Manipulae.Domain.Requests.Video;
using Manipulae.Exception.ExceptionBase;

namespace Manipulae.Infrastructure.Service.YoutubeApi
{
    public class YouTubeService : IYoutubeService
    {
        private readonly HttpClient _httpClient;
        private readonly YoutubeSettingsRequest _youTubeSettings;

        public YouTubeService(IOptions<YoutubeSettingsRequest> youTubeSettings)
        {
            _httpClient = new HttpClient();
            _youTubeSettings = youTubeSettings.Value;
        }

        public async Task<ListVideoResponse> GetVideosAsync(VideoRequest req)
        {
            var url = $"{_youTubeSettings.BasedUrl}&maxResults={_youTubeSettings.MaxResults}&regionCode={_youTubeSettings.RegionCode}&key={_youTubeSettings.ApiKey}";

            url += $"&q={_youTubeSettings.Theme}";

            if (!string.IsNullOrEmpty(req.q))
                url += $"&q={req.q}";
            
            if (!string.IsNullOrEmpty(req.Titulo))
                url += $"&q={req.Titulo}";
            
            if (!string.IsNullOrEmpty(req.Autor))
                url += $"&channelTitle={req.Autor}";
            
            if (req.DataCriacao.HasValue)
                url += $"&publishedAfter={req.DataCriacao.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")}";

            if (req.Duracao.HasValue)
                url += $"&videoDuration={req.Duracao.Value}";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                throw new BadRequestException($"Failed to fetch data from YouTube API: {response.ReasonPhrase}");

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var searchResult = JsonDocument.Parse(jsonResponse);

            var videos = searchResult.RootElement.GetProperty("items")
                .EnumerateArray()
                .Select(item => new ShortVideoResponse
                {
                    Titulo = item.GetProperty("snippet").GetProperty("title").GetString(),
                    Autor = item.GetProperty("snippet").GetProperty("channelTitle").GetString(),
                    DataCriacao = item.GetProperty("snippet").GetProperty("publishedAt").GetDateTime(),
                    Descricao = item.GetProperty("snippet").GetProperty("description").GetString(),
                    Canal = item.GetProperty("snippet").GetProperty("channelTitle").GetString()
                });

            return new ListVideoResponse { data = videos.ToList() };
        }
    }
}
