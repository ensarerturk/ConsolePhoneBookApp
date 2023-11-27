using ConsolePhoneBookApp.Contracts;
using ConsolePhoneBookApp.Directory;

class Program
{
    static void Main()
    {
        IDirectory rehber = new ConsoleDirectory();
        rehber.ShowMenu();
    }
}