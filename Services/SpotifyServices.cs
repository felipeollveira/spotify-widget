using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using spotify_widget.Models;

namespace spotify_widget.Services
{
    class SpotifyServices
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<Track?> ConnectApi(string url)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();

                // Desserializa o JSON para um objeto Track
                var track = JsonSerializer.Deserialize<Track>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return track;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar com a API: {ex.Message}");
                return null;
            }
        }
    }
}
