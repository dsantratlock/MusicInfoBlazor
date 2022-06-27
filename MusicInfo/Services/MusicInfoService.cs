using System.Text;
using System.Text.Json;
using System.Net;
using Microsoft.Extensions.Options;
using MusicInfo.Models;

namespace MusicInfo.Services
{
    internal class MusicInfoService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public MusicInfoService(IOptions<MusicInfoOptions> options)
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri(options.Value.Uri!)
            };

            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<List<TrackData>?> GetMusicInfoAsync(string? searchParameters = null)
        {
            HttpResponseMessage response = await _client.GetAsync("search?entity=musicTrack&limit=24&term=" + searchParameters);

            if (!response.IsSuccessStatusCode) {
                throw new Exception(response.ReasonPhrase ?? "Failure to retrieve music info");
            }
            var bodyContent = await response.Content.ReadAsStreamAsync();
            MusicInfoResults? musicInfoResults = await JsonSerializer.DeserializeAsync<MusicInfoResults>(bodyContent, _jsonSerializerOptions);

            if (musicInfoResults?.Results.Count > 0)
            {
                return musicInfoResults.Results;
            }
            else
            {
                return new List<TrackData>();
            }
        }

    }
    public static class MusicInfoServiceExtensions
    {
        public static IServiceCollection AddMusicInfoService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MusicInfoOptions>(configuration.GetSection("MusicInfo"));
            services.AddSingleton<MusicInfoService>();
            return services;
        }
    }
}
