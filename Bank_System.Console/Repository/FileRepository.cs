using System.Data.Common;
using System.Text.Json;
using Models;
public class FileRepository : IRepository
{

    public void AddUserAccount(Account account)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        string jsonString = JsonSerializer.Serialize(account,options);
        using FileStream fileStream = new FileStream("data.json",FileMode.Create);
        using StreamWriter streamWriter = new StreamWriter(fileStream);
        streamWriter.Write(jsonString);
    }

    public void DeleteUserAccount(Guid id)
    {
        throw new NotImplementedException();
    }

    public Account GetAccountDetailsById(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Account> GetAllAccounts()
    {
        throw new NotImplementedException();
    }
}