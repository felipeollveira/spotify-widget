using System;
using System.Net.Http;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using spotify_widget.Services;
using spotify_widget.Models;
using static System.Net.WebRequestMethods;

namespace spotify_widget
{
    public partial class MainWindow : Window
    {
        private readonly SpotifyViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new SpotifyViewModel();
            DataContext = _viewModel;

            string url = "http://localhost:8888/current";
            
            FetchData(url);
        }

        public async void FetchData(string url)
        {
            try
            {
                SpotifyServices spotifyService = new SpotifyServices();
                Track? currentTrack = await spotifyService.ConnectApi(url);

                // Atribui o track à ViewModel (isso atualizará automaticamente a UI)
                _viewModel.CurrentTrack = currentTrack;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
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
