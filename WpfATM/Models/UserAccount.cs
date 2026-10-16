using WpfATM.Common;

namespace WpfATM.Models;

public class UserAccount
{
    public int Pin { get; set; }
    
    public int AccountNumber { get; set; }
    
    public string FullName { get; set; } = string.Empty;
    
    public decimal Balance { get; set; }
}