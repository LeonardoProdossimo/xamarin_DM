using Microsoft.Maui.Controls;

namespace PessoasApp;

public partial class App : Application
{
    public App(MainPage mainPage)
    {
        InitializeComponent();
        MainPage = mainPage;
    }
}

