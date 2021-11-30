using System;


class animal
{
    public string sound;
    public int NumberOfLegs = 4;
    public int NumberOfEyes = 2;
}

class Tiger : animal
{ 
    public Tiger(string p)
    {
        sound = "growl";
        
        if(p=="sound")Console.WriteLine(sound);
        else if(p== "NumberOfLegs") Console.WriteLine(NumberOfLegs);
        else if (p== "NumberOfEyes") Console.WriteLine(NumberOfEyes);
    }
}

class Elephant : animal
{ 
    public Elephant(string p)
    {
        sound = "trumpet";
        
        if(p=="sound")Console.WriteLine(sound);
        else if (p== "NumberOfLegs") Console.WriteLine(NumberOfLegs);
        else if (p == "NumberOfEyes") Console.WriteLine(NumberOfEyes);
    }
}

class Lion : animal
{ 
    public Lion(string p)
    {
        sound = "roar";
        
        if(p=="sound")Console.WriteLine(sound);
        else if (p== "NumberOfLegs") Console.WriteLine(NumberOfLegs);
        else if (p == "NumberOfEyes") Console.WriteLine(NumberOfEyes);
    }
}

class Zebra : animal
{ 
    public Zebra(string p)
    {
        sound = "neigh";
        
        if(p=="sound")Console.WriteLine(sound);
        else if (p== "NumberOfLegs") Console.WriteLine(NumberOfLegs);
        else if (p == "NumberOfEyes") Console.WriteLine(NumberOfEyes);
    }
}

class Cow : animal
{ 
    public Cow(string p)
    {
        sound = "moo";
        
        if(p=="sound")Console.WriteLine(sound);
        else if (p== "NumberOfLegs") Console.WriteLine(NumberOfLegs);
        else if (p == "NumberOfEyes") Console.WriteLine(NumberOfEyes);
    }
}

class Bird : animal
{ 
    public Bird(string p)
    {
        sound = "chirp";
        NumberOfLegs = 2;
        
        if(p=="sound")Console.WriteLine(sound);
        else if (p== "NumberOfLegs") Console.WriteLine(NumberOfLegs);
        else if (p == "NumberOfEyes") Console.WriteLine(NumberOfEyes);
    }
}

class Program
{

    public static void Main()
    {

        Console.WriteLine("Tiger\tElephant\tLion\tZebra\tCow\tBird\n\n");
        Console.WriteLine("Enter the name of animal that you are interested in:\n");

        string name = Console.ReadLine();

        Console.WriteLine("Enter the property you are interested in:" +
            "sound\tNumberOfLegs\tNumberOfEyes"+"\n");

        string property_ = Console.ReadLine();

        animal a;

        if(name=="Tiger")           a = new Tiger(property_);
        else if(name=="Elephant")   a = new Elephant(property_);
        else if(name=="Lion")       a = new Lion(property_);
        else if(name=="Zebra")      a = new Zebra(property_);
        else if(name=="Cow")        a = new Cow(property_);
        else if(name=="Bird")       a = new Bird(property_);
        else
        {
            Console.WriteLine("Sorry! Not found.\n");
        }
        
    }
    
    
}
