using AFClient = Patterns.AbstractFactory.Client;
using FMClient = Patterns.FactoryMethod.Client;
using TMClient = Patterns.TemplateMethod.Client;

Action IClient;

do
{
    Console.WriteLine("""
    0 - Close app,
    1 - Abstract Factory,
    2 - Factory Method,
    3 - Template Method,
    """);

    var input = Console.ReadLine();

    if (input == "0") break;

    IClient = input switch
    {
        "1" => AFClient.Do,
        "2" => FMClient.Do,
        "3" => TMClient.Do,
        // TODO: Create new Patterns
        _ => throw new NotImplementedException()
    };

    IClient.Invoke();

} while (true);