using ConsolePhoneBookApp.Contracts;

namespace ConsolePhoneBookApp.Directory;

public class ConsoleDirectory : IDirectory
{
    private readonly List<Person.Person> _persons;

    public ConsoleDirectory()
    {
        _persons = new List<Person.Person>()
        {
            new Person.Person("Kazim", "Karabekir", "123123123"),
            new Person.Person("İbrahim", "Kalpazan", "456456456"),
            new Person.Person("Arap", "Ali", "789789789"),
            new Person.Person("Kenan", "Komutan", "147147147"),
            new Person.Person("Fatih", "Altayli", "258258258"),
        };
    }
    
    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("Please select the operation you want to perform :)\n" +
                              "*******************************************\n" +
                              "(1) Registering a New Number\n" +
                              "(2) Delete Existing Number\n" +
                              "(3) Update Existing Number\n" +
                              "(4) List Directory\n" +
                              "(5) Searching the Directory");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                ProcessDo(choice);
            }
            else
            {
                Console.WriteLine("You entered an invalid number. Please try again.");
            }
        }
    }

    private void ProcessDo(int choice)
    {
        var guideActions = new DirectoryOperations(_persons);

        switch (choice)
        {
            case 1:
                guideActions.AddNewNumber();
                break;
            case 2:
                guideActions.DeletePerson();
                break;
            case 3:
                guideActions.UpdatePerson();
                break;
            case 4:
                guideActions.DirectoryList();
                break;
            case 5:
                guideActions.DirectorySearch();
                break;
        }
    }
}