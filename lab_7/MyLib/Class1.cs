namespace Mylib;

[MyComment("Enum Classification")]
public enum eClassificationAnimal
{
    Herbivores,
    Carnivores,
    Omnivores
}

[MyComment("Enum Food")]
public enum eFavouriteFood
{
    Meat,
    Plants,
    Everything
}

[MyComment("Class Animal")]
public class Animal
{
    public string Country { get; set; }
    public bool HideFromOtherAnimals { get; set; }
    public string Name { get; set; }
    public eClassificationAnimal WhatAnimal { get; set; }

    public Animal(string country, string name, bool hidefromotheranimals, eClassificationAnimal classificationAnimal)
    {
        Country = country;
        Name = name;
        WhatAnimal = classificationAnimal;
        HideFromOtherAnimals = hidefromotheranimals;
    }

    public void Deconstruct()
    {
        Country = "";
        Name = "";
    }

    public eClassificationAnimal GetClassificationAnimal()
    {
        return WhatAnimal;
    }

    public eFavouriteFood GetFavouriteFood()
    {
        eFavouriteFood food;
        if (WhatAnimal == eClassificationAnimal.Herbivores)
        {
            food = eFavouriteFood.Meat;
        }
        else if (WhatAnimal == eClassificationAnimal.Omnivores)
        {
            food = eFavouriteFood.Everything;
        }
        else { food = eFavouriteFood.Plants; }
        return food;
    }

    public void SayHello()
    {
        Console.WriteLine($"I am {Name}");
    }
}


[MyComment("Class Cow")]
public class Cow : Animal
{
    public Cow() : base("Russia", "Cow", true, eClassificationAnimal.Carnivores) { }

    public eFavouriteFood GetFavouiteFood()
    {
        return base.GetFavouriteFood();
    }

    public new void SayHello()
    {
        base.SayHello();
    }
}

[MyComment("Class Lion")]
public class Lion : Animal
{
    public Lion() : base("Africa", "Lion", false, eClassificationAnimal.Herbivores) { }

    public eFavouriteFood GetFavouiteFood()
    {
        return base.GetFavouriteFood();
    }

    public new void SayHello()
    {
        base.SayHello();
    }
}

[MyComment("Class Pig")]
public class Pig : Animal
{
    public Pig() : base("Russia", "Pig", true, eClassificationAnimal.Omnivores) { }

    public eFavouriteFood GetFavouiteFood()
    {
        return base.GetFavouriteFood();
    }

    public new void SayHello()
    {
        base.SayHello();
    }
}

public class MyComment : Attribute
{
    public string? Comment { get; }
    public MyComment() { }
    public MyComment(string comment) => Comment = comment;
}