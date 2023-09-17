using Patterns.FactoryMethod.ConcreteCreator;

namespace Patterns.FactoryMethod;

public class Client
{
    public static void Do()
    {
        var v8mCar = new V8Car();

        v8mCar.PrintDetails();

        var twinTurboCar = new TwinTurboCar();

        twinTurboCar.PrintDetails();
    }
}