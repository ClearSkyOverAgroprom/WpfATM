using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using WpfATM.Models;

namespace WpfATM.Business;

public class AccountProvider
{
    private static Dictionary<int, UserAccount> _accounts = [];

    public static void InitAccountProvider()
    {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BankData.json");
        var fileArray = File.ReadAllLines(path);
        _accounts = 
    }

    public static bool LoginValid(string input, out UserAccount? account)
    {
        account = null;
        return int.TryParse(input, out var number) && // Input muss ein int sein
               number is >= 1_000 and <= 9_999 && // Zahl muss zwischen 1.000 und 9.999 sein
               _accounts.TryGetValue(number, out account); // Es muss ein Eintrag in "_accounts" für die Nummer vorhanden sein
    }

    public static void Save()
    {
        
    }
    
}