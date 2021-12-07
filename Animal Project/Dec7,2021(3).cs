using System;
using System.Collections.Generic;


abstract class Animal
{
    public abstract void Sound();
}

class Tiger : Animal
{
    public override void Sound()
    {
        Console.WriteLine("growl");
    }
}

class Lion : Animal
{
    public override void Sound()
    {
        Console.WriteLine("roar");
    }
}

class Cow : Animal
{
    public override void Sound()
    {
        Console.WriteLine("moo");
    }
}

class Elephant : Animal
{
    public override void Sound()
    {
        Console.WriteLine("moo");
    }
}

class Bird : Animal
{
    public override void Sound()
    {
        Console.WriteLine("chirp");
    }
}

class Zebra : Animal
{
    public override void Sound()
    {
        Console.WriteLine("neigh");
    }
}

enum AnimalType
{ 
    Tiger = 1,
    Lion = 2,
    Zebra = 3,
    Elephant = 4,
    Bird = 5,
    Cow = 6
}

public class Program
{
    public static Dictionary<string, Type> dict;
     
    public static void Main()
    {

        PredefinedTypes();
        Console.WriteLine("Choose an animal:\n" + "1. Tiger\n" +
            "2. Lion\n" +
            "3. Zebra\n" +
            "4. Elephant\n" +
            "5. Bird\n" +
            "6. Cow\n");
        here:
        int inputAnimal = 0;
        try
        {
            inputAnimal = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Input should be an integer\nTry again\n");
            goto here;
        }
        var animalType = (AnimalType)inputAnimal;
        string stringValue = animalType.ToString();

        Animal animal = GetAnimal(stringValue);

        if (animal == null) goto here;

        animal.Sound();
    }

    private static Animal GetAnimal(string name)
    {
        Animal animal = null;

        try
        {
            animal = (Animal)Activator.CreateInstance(dict[name]);
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine("The number must be between 1 to 6");
            Console.WriteLine("Try again\n");
        }
        catch(Exception ex)
        {
            Console.WriteLine("This is some other exception");
        }

        return animal;
    }

    public static void PredefinedTypes()
    {
        dict = new Dictionary<string, Type>();

        dict.Add("Tiger", typeof(Tiger));
        dict.Add("Lion", typeof(Lion));
        dict.Add("Bird", typeof(Bird));
        dict.Add("Elephant", typeof(Elephant));
        dict.Add("Zebra", typeof(Zebra));
        dict.Add("Cow", typeof(Cow));


    }
}
