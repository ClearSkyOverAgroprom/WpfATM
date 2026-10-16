using System.Text.RegularExpressions;
using System.Windows;
using WpfATM.Common;
using WpfATM.Models;

namespace WpfATM;

public partial class Deposit : Window
{
    public DepositResult Result { get; private set; } = DepositResult.None;

    public void SetResult(DepositResult result)
    {
        Result = result;
        Close();
    }
    private readonly UserAccount _account;
    public Deposit(UserAccount account)
    {
        InitializeComponent();
        
        _account = account;
    }
    
    private void CancelClick(object sender, RoutedEventArgs e)
    {
        //TODO Closes Deposit and opens menu
    }
    
    private void ConfirmDepositClick(object sender, RoutedEventArgs e)
    {
        //Validates Deposit Amount
        string cashAmount = depositAmount.Text;
            
        cashAmount = cashAmount.Replace(".", ",");
        if (cashAmount != null && !Regex.IsMatch(cashAmount, @"^\d+[,]\d{2}|\d+|\d +"))
        {
            Console.WriteLine("Invalid Format, try Again.");
        }
        else
        {
            //TODO sends validated CashAmount down to business
        }
    }
}