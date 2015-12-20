namespace CookAdvisor.Client.CustomViews
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;

    public sealed partial class LabeledTextbox : UserControl
    {
        public LabeledTextbox()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
        
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(LabeledTextbox), new PropertyMetadata(null, OnLabelChanged));

        private static void OnLabelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as LabeledTextbox;
            control.textBlockLabel.Text = e.NewValue.ToString();
        }


        public Brush TextColor
        {
            get { return (Brush)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextColorProperty =
            DependencyProperty.Register("TextColor", typeof(Brush), typeof(LabeledTextbox), new PropertyMetadata(null, OnColorChanged));

        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as LabeledTextbox;
            control.textBlockLabel.Foreground = (Brush)e.NewValue;
        }

        public string UserInput
        {
            get { return (string)GetValue(UserInputProperty); }
            set { SetValue(UserInputProperty, value); }
        }

        public static readonly DependencyProperty UserInputProperty =
            DependencyProperty.Register("UserInput", typeof(string), typeof(LabeledTextbox), new PropertyMetadata(string.Empty, OnInputChanged));

        private void textBoxInput_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            UserInput = this.textBoxInput.Text.ToString();
        }

        private void passwordBoxInput_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            UserInput = this.textBoxInput.Text.ToString();
        }
        
        private static void OnInputChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as LabeledTextbox;
            control.textBoxInput.Text = e.NewValue.ToString();
            control.passwordBoxInput.Password = e.NewValue.ToString();
        }
        
        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsPassword.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPasswordProperty =
            DependencyProperty.Register("IsPassword", typeof(bool), typeof(LabeledTextbox), new PropertyMetadata(false, OnIsPasswordChanged));

        private static void OnIsPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as LabeledTextbox;
            var isPassword = (bool)e.NewValue;
            if (!isPassword)
            {
                control.textBoxInput.Visibility = Visibility.Visible;
                control.passwordBoxInput.Visibility = Visibility.Collapsed;
            }
            else
            {
                control.textBoxInput.Visibility = Visibility.Collapsed;
                control.passwordBoxInput.Visibility = Visibility.Visible;
            }
        }
    }
}
