namespace ConsolePhoneBookApp.Person;

public class Person
{
    private string name;
    private string surname;
    private string phoneNumber;

    public Person(string name, string surname, string phoneNumber)
    {
        this.name = name;
        this.surname = surname;
        this.phoneNumber = phoneNumber;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Surname
    {
        get { return surname; }
        set { surname = value; }
    }

    public string PhoneNumber
    {
        get { return phoneNumber; }
        set { phoneNumber = value; }
    }
}