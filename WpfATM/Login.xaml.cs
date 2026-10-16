using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfATM.Common;
using WpfATM.Models;
using WpfATM.Business;

namespace WpfATM;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class Login : Window
{
    public LoginResult Result { get; private set; } = LoginResult.None;
    
    public UserAccount? UserAccount { get; private set; }

    private void SetResult(LoginResult result)
    {
        Result = result;
        Close();
    }
    
    public Login()
    {
        InitializeComponent();
    }

    private void ButtonExit_OnClick(object sender, RoutedEventArgs e)
    {
        //Exit Button Shuts the Application Down
        SetResult(LoginResult.Exit);
    }


    private void OpenCreateAccountWindowClick(object sender, RoutedEventArgs e)
    {
        SetResult(LoginResult.CreateAccount);
    }


    private void ValidatePinAndLogIn(object sender, RoutedEventArgs e)
    {
        
        string input = PinTextBox.Text;

        if (AccountProvider.LoginValid(input, out var account))
        {
            //TODO pin gets send down to business layer
            UserAccount = account;
            SetResult(LoginResult.Success);
        }
        else if (input == string.Empty)
        {
            MessageBox.Show("Enter Pin First");
        }
        else
        {
            MessageBox.Show("Invalid Pin");
        }
            
    }

    private void Login_OnLoaded(object sender, RoutedEventArgs e)
    {
        
    }
}