namespace CookAdvisor.Client.Notifications
{
    using NotificationsExtensions.Toasts;
    using Windows.UI.Notifications;

    public class Notifier
    {
        public static void ShowToast(string topMessage, string bottomMessage)
        {
            var content = new ToastContent()
            {
                Visual = new ToastVisual()
                {
                    TitleText = new ToastText()
                    {
                        Text = topMessage
                    },

                    BodyTextLine1 = new ToastText()
                    {
                        Text = bottomMessage
                    },

                    AppLogoOverride = new ToastAppLogo()
                    {
                        Crop = ToastImageCrop.Circle,
                        Source = new ToastImageSource(@"../Assets/logo.jpg")
                    }
                }
            };

            var xml = content.GetXml();
            var toast = new ToastNotification(xml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
