using System.Text.RegularExpressions;
using System.Windows;
using WpfATM.Common;
using WpfATM.Models;

namespace WpfATM;

public partial class Withdraw : Window
{
    public WithdrawResult Result { get; private set; } = WithdrawResult.None;

    public void SetResult(WithdrawResult result)
    {
        Result = result;
        Close();
    }
    
    private readonly UserAccount _account;
    
    public Withdraw(UserAccount account)
    {
        InitializeComponent();
        
        _account = account;
    }

    private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
    {
        SetResult(WithdrawResult.BackToMenu);
    }

    private void ConfirmWithdrawClick(object sender, RoutedEventArgs e)
    {
        //validates withdraw amount 
        string cashAmount = withdrawAmount.Text;
            
        cashAmount = cashAmount.Replace(".", ",");
        if (cashAmount != null && !Regex.IsMatch(cashAmount, @"^\d+[,]\d{2}|\d+|\d+"))
        {
            Console.WriteLine("Invalid Format, try Again.");
        }
        else if (cashAmount != null)
        {
            //TODO sends validated cashAmount down to business
        }
    }
}