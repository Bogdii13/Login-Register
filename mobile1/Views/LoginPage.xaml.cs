namespace mobile1.Views;
using mobile1.ViewModels;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        this.BindingContext = new LoginViewModel(this.Navigation);
    }
}