using System.Windows;
using System.Windows.Controls;
using UMU_GUI.ViewModels;

namespace UMU_GUI.Views
{
    /// <summary>
    /// Interaction logic for LoginViewModel.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }
    }

    public class PlaceHolderHelper : DependencyObject
    {
        #region PlaceHolderText
        public static bool GetPlaceHolderText(DependencyObject obj)
        {
            return (bool)obj.GetValue(PlaceHolderTextProperty);
        }
        public static void SetPlaceHolderText(DependencyObject obj, string value)
        {
            obj.SetValue(PlaceHolderTextProperty, value);
        }
        public static readonly DependencyProperty PlaceHolderTextProperty =
            DependencyProperty.RegisterAttached("PlaceHolderText", typeof(string),
                typeof(PlaceHolderHelper),
                new UIPropertyMetadata(string.Empty, PlaceHolderTextChanged));
        private static void PlaceHolderTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is PasswordBox)) return;
            ((PasswordBox)d).PasswordChanged +=
                (sender, args) =>
                {
                    var pb = sender as PasswordBox;
                    pb.SetValue(HasPasswordProperty, (pb.Password.Length > 0));
                };
        }
        #endregion
        #region HasPassword
        public bool HasPassword
        {
            get { return (bool)GetValue(HasPasswordProperty); }
            set { SetValue(HasPasswordProperty, value); }
        }
        private static readonly DependencyProperty HasPasswordProperty =
            DependencyProperty.RegisterAttached("HasPassword",
                typeof(bool), typeof(PlaceHolderHelper),
                new FrameworkPropertyMetadata(false));
        #endregion
    }
}
