using System.Windows;
using WpfATM.Common;
using WpfATM.Models;

namespace WpfATM;

public partial class Menu : Window
{
    public MenuResult Result { get; private set; } = MenuResult.None;

    public void SetResult(MenuResult result)
    {
        Result = result;
        Close();
    }
    
    private readonly UserAccount _account;
    public Menu(UserAccount account)
    {
        InitializeComponent();

        _account = account;
    }

    private void OpenLogInWindowClick(object sender, RoutedEventArgs e)
    {
        SetResult(MenuResult.Logout);
    }

    private void OpenWithdrawWindowClick(object sender, RoutedEventArgs e)
    {
        SetResult(MenuResult.Withdraw);
    }

    private void OpenDepositWindowClick(object sender, RoutedEventArgs e)
    {
        SetResult(MenuResult.Deposit);
    }
}