namespace chapter3;

public class Program
{
    static void Main(string[] args)
    {
        AccountOBJ ozaiiAccount = new AccountOBJ("ozaiithejava", "ServerSideDeveloper");
        AccountOBJ emrullahAccount = new AccountOBJ("emrullah", "Boss");
        
        Console.WriteLine(ozaiiAccount.AccountName);
        Console.WriteLine(emrullahAccount.AccountState);
    }
}