using System;
using System.Net.Http;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace spotify_widget
{
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _timer;
        private int _progressMs;
        private int _durationMs;
        private string _currentTrackUri = "";  // Variável para armazenar o URI da música atual

        public MainWindow()
        {
            InitializeComponent();
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };  // Intervalo de 5 segundos
            _timer.Tick += (s, e) => UpdateProgressBar();
            _timer.Start();
            _ = LoadData();  // Carregar os dados ao iniciar
        }

        private async Task LoadData()
        {
            try
            {
                string apiUrl = "http://localhost:8888/current";
                string response = await FetchData(apiUrl);
                var json = JsonDocument.Parse(response).RootElement;

                // 🔹 Obtém informações da música
                string? trackName = json.TryGetProperty("track", out var track) && track.TryGetProperty("name", out var nameProp)
                    ? nameProp.GetString()
                    : "Desconhecido";

                string artist = json.TryGetProperty("track", out var trackArtists) && trackArtists.TryGetProperty("artists", out var artistsArray)
                    ? string.Join(", ", artistsArray.EnumerateArray().Select(a => a.GetString()))
                    : "Artista Desconhecido";

                string? albumName = json.TryGetProperty("track", out var album) && album.TryGetProperty("name", out var albumProp)
                    ? albumProp.GetString()
                    : "Desconhecido";

                string? albumImageUrl = json.TryGetProperty("track", out var trackImage) && trackImage.TryGetProperty("images", out var imagesArray) && imagesArray.GetArrayLength() > 0
                    ? imagesArray[0].GetProperty("url").GetString()
                    : "https://via.placeholder.com/80";

                _progressMs = json.TryGetProperty("progressMs", out var progressProp) ? progressProp.GetInt32() : 0;
                _durationMs = _progressMs;

                // 🔹 Detecta mudança de música comparando o URI
                string newTrackUri = json.TryGetProperty("track", out var trackUriProp) && trackUriProp.TryGetProperty("uri", out var uriProp)
                    ? uriProp.GetString()
                    : string.Empty;

                if (newTrackUri != _currentTrackUri) // Se o URI mudou (música pulada ou trocada)
                {
                    _currentTrackUri = newTrackUri; // Atualiza o URI da música atual

                    // Atualiza a UI com os novos dados
                    Dispatcher.Invoke(() =>
                    {
                        TrackName.Text = trackName;
                        ArtistName.Text = artist;
                        AlbumName.Text = albumName;

                        try
                        {
                            AlbumImage.Source = new BitmapImage(new Uri(albumImageUrl));
                        }
                        catch (Exception imgEx)
                        {
                            Console.WriteLine("Erro ao carregar imagem: " + imgEx.Message);
                        }

                        ProgressBar.Maximum = _durationMs;
                        ProgressBar.Value = _progressMs;
                    });
                }
                else
                {
                    // Se a música não mudou, apenas atualiza o progresso
                    Dispatcher.Invoke(() =>
                    {
                        ProgressBar.Maximum = _durationMs;
                        ProgressBar.Value = _progressMs;
                    });
                }

            }
            catch (Exception ex)
            {
                Dispatcher.Invoke(() =>
                {
                    TrackName.Text = "Erro ao carregar";
                    ArtistName.Text = ex.Message;
                });

                Console.WriteLine("Erro ao carregar os dados: " + ex.Message);
            }
        }

        private static async Task<string> FetchData(string url)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private void UpdateProgressBar()
        {
            // Verifica se o progresso já chegou ao final da música
            if (_progressMs >= _durationMs)
            {
                // A música terminou, então recarrega os dados da próxima música
                _ = LoadData(); // Chama o método para carregar a próxima música
                _progressMs = 0; // Reseta o progresso para 0
                ProgressBar.Value = 0; // Reseta a barra de progresso
            }
            else
            {
                // Continua atualizando o progresso
                _progressMs += 1000; // Atualiza de 1 em 1 segundo
                Dispatcher.Invoke(() => ProgressBar.Value = _progressMs);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Permite mover a janela ao clicar e arrastar com o mouse
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
