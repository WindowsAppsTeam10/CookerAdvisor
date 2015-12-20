namespace CookAdvisor.Client.Views
{
    using System;
    using CookAdvisor.Client.ViewModels;
    using Windows.Media.Capture;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Imaging;
    public sealed partial class AddRecipePage : Page
    {
        public AddRecipePage()
        {
            this.InitializeComponent();
            this.ViewModel = new AddRecipePageViewModel();
        }

        public AddRecipePageViewModel ViewModel
        {
            get { return this.DataContext as AddRecipePageViewModel; }
            set { this.DataContext = value; }
        }

        private void OnCameraClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            InitCamera();
        }

        private async void InitCamera()
        {
            var camera = new CameraCaptureUI();
            var photo = await camera.CaptureFileAsync(CameraCaptureUIMode.Photo);
            if (photo != null)
            {
                this.imageView.Source = new BitmapImage(new Uri(photo.Path));
            }
        }
    }
}
