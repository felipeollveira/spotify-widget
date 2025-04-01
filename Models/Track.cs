using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace spotify_widget.Models
{
    public class Track
    {
        [JsonPropertyName("isPlaying")]
        public bool IsPlaying { get; set; }

        [JsonPropertyName("duration_ms")]
        public int DurationMs { get; set; }

        [JsonPropertyName("progressMs")]
        public int ProgressMs { get; set; }

        [JsonPropertyName("track")]
        public TrackDetails? Details { get; set; }

        public string FormattedProgress
        {
            get
            {
                TimeSpan time = TimeSpan.FromMilliseconds(ProgressMs);
                return $"{(int)time.TotalMinutes}:{time.Seconds:00}";
            }
        }

        public string FormattedDuration
        {
            get
            {
                TimeSpan time = TimeSpan.FromMilliseconds(DurationMs);
                return $"{(int)time.TotalMinutes}:{time.Seconds:00}";
            }
        }

    }

    public class TrackDetails
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("artists")]
        public required List<string> Artists { get; set; }

        [JsonPropertyName("album")]
        public required string Album { get; set; }

        [JsonPropertyName("uri")]
        public string? Uri { get; set; }

        [JsonPropertyName("images")]
        public required List<ImageData> Images { get; set; }

        public string GetBestImage()
        {
            return Images?.Count > 0 ? Images[0].Url : "https://via.placeholder.com/80";
        }




    }



   
}
