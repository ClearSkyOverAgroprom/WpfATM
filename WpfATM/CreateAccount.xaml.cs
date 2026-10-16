using System.Text.RegularExpressions;
using System.Windows;
using WpfATM.Common;


namespace WpfATM;

public partial class CreateAccount : Window
{
    public CreateAccountResult Result { get; private set; } = CreateAccountResult.None;
    public CreateAccount()
    {
        InitializeComponent();
    }

    public void SetResult(CreateAccountResult result)
    {
        Result = result;
        Close();
    }
    private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
    {
        SetResult(CreateAccountResult.Cancelled);
    }
    
    private void ConfirmClick(object sender, RoutedEventArgs e)
    {
        //gets user inputs and send them down to business layer
        var newFullName = FullNameTextBox.Text;
        var newPin = PinTextbox.Text;
        var newBankProvider = BankProviderComboBox.SelectedItem as string;

        if (Regex.IsMatch(newFullName, "@/^[a-z ,.'-]+$/i$"))
        {
            //TODO send User Full Name down to business
        }
        else
        {
            MessageBox.Show("Your Name has an invalid format");
        }

        if (Regex.IsMatch(newPin, @"^\\d{4}$\$"))
        {
            //TODO send user Pin down to business
        }
        else
        {
            MessageBox.Show("Your Pin has an invalid format");
        }
            
        
        
    }
}