using System.Reflection;
//using dotenv.net;

namespace microsoft.botsay;

internal class Program
{
    static void Main(string[] args)
    {
        //Dotenv.Load();

        //string databaseUrl = Environment.GetEnvironmentVariable("CHAT_GPT_KEY");
        Console.Write("Ecris ! : ");
        string text = Console.ReadLine();
        Console.WriteLine(text);
    }
}