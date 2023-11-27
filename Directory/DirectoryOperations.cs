namespace ConsolePhoneBookApp.Directory;

public class DirectoryOperations
{
    private readonly List<Person.Person> _persons;
    
    public DirectoryOperations(List<Person.Person> persons)
    {
        this._persons = persons;
    }

    public void AddNewNumber()
    {
        Console.Write("Please enter name         : ");
        string name = Console.ReadLine();

        Console.Write("Please enter last name    : ");
        string lastName = Console.ReadLine();

        Console.Write("Please enter phone number : ");
        string phone = Console.ReadLine();
        
        _persons.Add(new Person.Person(name, lastName, phone));
        Console.WriteLine("New number added successfully.\n");
    }

    public void DeletePerson()
    {
        Console.Write("Please enter the first or last name of the person whose number you want to delete: ");
        string wantedNameSurname = Console.ReadLine().Trim();

        Person.Person person = _persons.FirstOrDefault(x =>
            string.Equals(x.Name, wantedNameSurname, StringComparison.OrdinalIgnoreCase) ||
            string.Equals(x.Surname, wantedNameSurname, StringComparison.OrdinalIgnoreCase));

        if (person == null)
        {
            Console.WriteLine("Data matching your search criteria was not found in the directory. Please make a selection.\n" +
                              " * To end deletion : (1)\n" +
                              " * To retry: (2)\n" +
                              "=>");

            if (int.TryParse(Console.ReadLine(), out int deleteChoise))
            {
                if (deleteChoise == 2)
                {
                    DeletePerson();
                }
                else if (deleteChoise != 1)
                {
                    Console.WriteLine("You made an invalid selection. Delete operation canceled.");
                }
                
            }
            else
            {
                Console.WriteLine("You made an invalid selection. Delete operation canceled.");
            }
        }
        else
        {
            Console.Write($"{person.Name} is about to be deleted from the directory, do you confirm (y/n): ");
            string approval = Console.ReadLine().ToLower();

            if (approval == "y")
            {
                _persons.Remove(person);
                Console.WriteLine("Person deleted successfully.\n");
            }
            else
            {
                Console.WriteLine("Delete operation canceled.");
            }
        }
    }

    public void UpdatePerson()
    {
        Console.Write("Please enter the first or last name of the person whose number you want to update: ");
        string wantedNameSurname = Console.ReadLine().Trim();

        Person.Person person = _persons.FirstOrDefault(x =>
            string.Equals(x.Name, wantedNameSurname, StringComparison.OrdinalIgnoreCase) ||
            string.Equals(x.Surname, wantedNameSurname, StringComparison.OrdinalIgnoreCase));

        if (person == null)
        {
            Console.WriteLine("Data matching your search criteria was not found in the directory. Please make a selection.\n" +
                              " * To end the update : (1)\n" +
                              " * To retry: (2)\n" +
                              "=>");

            if (int.TryParse(Console.ReadLine(), out int updateChoise))
            {
                if (updateChoise == 2)
                {
                    UpdatePerson();
                }
                else if (updateChoise != 1)
                {
                    Console.WriteLine("You made an invalid selection. The update operation was canceled.");
                }
            }
            else
            {
                Console.WriteLine("You made an invalid selection. The update operation was canceled.");
            }
        }
        else
        {
            Console.WriteLine($"Current information of the person named {person.Name}:");
            
            Console.Write("Please enter new name         : ");
            string newName = Console.ReadLine();
            
            Console.Write("Please enter new last name    : ");
            string newSurname = Console.ReadLine();
            
            Console.Write("Please enter new phone number : ");
            string newPhone = Console.ReadLine();

            person.Name = newName;
            person.Surname = newSurname;
            person.PhoneNumber = newPhone;
            
            Console.WriteLine("Contact updated successfully.\n");
        }
    }

    public void DirectoryList()
    {
        Console.WriteLine("Phone Book");
        Console.WriteLine("**********************************************");

        foreach (var person in _persons)
        {
            Console.WriteLine($"$Name : {person.Name}, Last Name : {person.Surname}, Phone Number : {person.PhoneNumber}");
        }
        
        Console.WriteLine("**********************************************");
    }

    public void DirectorySearch()
    {
        Console.Write("Select the type you want to search.\n" +
                          "**********************************************\n" +
                          "To search by first or last name: (1)\n" +
                          "To make a call by phone number: (2)\n" +
                          "=>");

        if (int.TryParse(Console.ReadLine(), out int searchChoise))
        {
            if (searchChoise == 1)
            {
                Console.Write("Please enter name or lastname : ");
                string searchedNameSurname = Console.ReadLine();

                var results = _persons.Where(x =>
                    x.Name.Contains(searchedNameSurname, StringComparison.OrdinalIgnoreCase) ||
                    x.Surname.Contains(searchedNameSurname, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                ShowSearchResults(results);
            }
            else if (searchChoise == 2)
            {
                Console.Write("Please enter phone number: ");
                string calledPhone = Console.ReadLine();

                var results = _persons
                    .Where(x => x.PhoneNumber.Contains(calledPhone, StringComparison.OrdinalIgnoreCase)).ToList();
                
                ShowSearchResults(results);
            }
            else
            {
                Console.WriteLine("You entered an invalid number. Please try again.");
            }
        }
        else
        {
            Console.WriteLine("You entered an invalid number. Please try again.");
        }
    }

    private void ShowSearchResults(List<Person.Person> results)
    {
        if (results.Count == 0)
        {
            Console.WriteLine("Search results: No data matching the criteria you searched for was found.");
        }
        else
        {
            Console.WriteLine("Your Search Results:");
            Console.WriteLine("**********************************************");

            foreach (var person in results)
            {
                Console.WriteLine($"$Name : {person.Name}, Last Name : {person.Surname}, Phone Number : {person.PhoneNumber}");
            }
            
            Console.WriteLine("**********************************************");
        }
    }
}