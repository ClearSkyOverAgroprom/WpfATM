using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfATM.Business;
using WpfATM.Common;
using WpfATM.Models;

namespace WpfATM;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        AccountProvider.InitAccountProvider();

        while (true)
        {
            var loginWindow = new Login();
            loginWindow.ShowDialog();

            switch (loginWindow.Result)
            {
                case LoginResult.Exit:
                    Current.Shutdown();
                    return;
                case LoginResult.CreateAccount:
                    var accountWindow = new CreateAccount();
                    accountWindow.ShowDialog();
                    break;
                case LoginResult.Success when loginWindow.UserAccount is not null:
                    var mainWindow = new Menu(loginWindow.UserAccount);
                    mainWindow.ShowDialog();
                    break;
            }

            var accountWindow2 = new CreateAccount();
            
            switch (accountWindow2.Result)
            {
                case CreateAccountResult.Cancelled:
                    loginWindow.ShowDialog();
                    break;
            }

            UserAccount placeholder = new UserAccount();
            
            var menuWindow = new Menu(placeholder);

            switch (menuWindow.Result)
            {
                case MenuResult.Logout:
                    loginWindow.ShowDialog();
                    break;
                case MenuResult.Deposit:
                    var depositWindow = new Deposit(placeholder);
                    depositWindow.ShowDialog();
                    break;
                case MenuResult.Withdraw:
                    var withdrawWindow = new Withdraw(placeholder);
                    withdrawWindow.ShowDialog();
                    break;
            }
            
            var withdrawWindow2 = new Withdraw(placeholder);
            
            switch(withdrawWindow2.Result)
            {
                case WithdrawResult.BackToMenu: 
                    var menuWindow2 = new Menu(placeholder);
                    menuWindow2.ShowDialog();
                    break;
                    
            }
            
            var depositWindow2 = new Deposit(placeholder);

            switch (depositWindow2.Result)
            {
                case DepositResult.BackToMenu:
                    var menuWindow3 = new Menu(placeholder);
                    menuWindow3.ShowDialog();
                    break;
            }
            
        }

    }

}
    