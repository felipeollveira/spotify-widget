using spotify_widget.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace spotify_widget.Models
{


    public class SpotifyViewModel : INotifyPropertyChanged
    {
        private Track _currentTrack;
        public Track CurrentTrack
        {
            get => _currentTrack;
            set
            {
                _currentTrack = value;
                OnPropertyChanged();
                // Notifica todas as propriedades dependentes
                OnPropertyChanged(nameof(TrackName));
                OnPropertyChanged(nameof(ArtistName));
                OnPropertyChanged(nameof(AlbumName));
                OnPropertyChanged(nameof(AlbumCoverUrl));
                OnPropertyChanged(nameof(IsPlaying));
                OnPropertyChanged(nameof(ProgressFormatted));
            }
        }

        // Propriedades para facilitar o binding
        public string TrackName => CurrentTrack?.Details?.Name ?? "Nenhuma música tocando";
        public string ArtistName => CurrentTrack?.Details?.Artists != null ?
                                   string.Join(", ", CurrentTrack.Details.Artists) : "Artista desconhecido";
        public string AlbumName => CurrentTrack?.Details?.Album ?? "Álbum desconhecido";
        public string AlbumCoverUrl => CurrentTrack?.Details?.GetBestImage() ?? "https://via.placeholder.com/80";
        public bool IsPlaying => CurrentTrack?.IsPlaying ?? false;

        public string ProgressFormatted
        {
            get
            {
                if (CurrentTrack == null) return "0:00 / 0:00";

                var progress = TimeSpan.FromMilliseconds(CurrentTrack.ProgressMs);
                var duration = TimeSpan.FromMilliseconds(CurrentTrack.DurationMs);
                return $"{progress:mm\\:ss} / {duration:mm\\:ss}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}