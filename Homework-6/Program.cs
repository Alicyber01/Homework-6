using System;
using System.Collections.Generic;
namespace ТемаПивоварня;
// Написать программу, содержащую решение следующих задач: Вы получили тему, по которой должны составить классы.
//Цель задания: Написать программу, в которой реализованы все принципы ООП.Для этого необходимо реализовать не менее 4 классов:
//● Один должен быть абстрактным
//● Должно быть не менее 2 наследников
//● Не менее 5 методов в каждом классе(необходимо показать свойство на чтение и на чтение-запись)
//● Не менее 4 свойств
//● Должно быть не менее 2 конструкторов в классах наследниках

public abstract class Beer
{
    public string Name { get; set; } 
    public double AlcoholContent { get; set; } 

    protected Beer(string name, double alcoholContent)
    {
        Name = name;
        AlcoholContent = alcoholContent;
    }

    public abstract string Description(); 

    public override string ToString()
    {
        return $"{Name} (Alcohol: {AlcoholContent}%)";
    }
}


public class Lager : Beer
{
    public int Bitterness { get; set; } 

    public Lager(string name, double alcoholContent, int bitterness)
        : base(name, alcoholContent)
    {
        Bitterness = bitterness;
    }

    public override string Description()
    {
        return $"Lager: {Name}, Alcohol: {AlcoholContent}%, Bitterness: {Bitterness} IBU";
    }
}


public class Ale : Beer
{
    public string Color { get; set; } 

    public Ale(string name, double alcoholContent, string color)
        : base(name, alcoholContent)
    {
        Color = color;
    }

    public override string Description()
    {
        return $"Ale: {Name}, Alcohol: {AlcoholContent}%, Color: {Color}";
    }
}


public class Brewery
{
    public string Name { get; set; } 
    private List<Beer> beers; 

    public Brewery(string name)
    {
        Name = name;
        beers = new List<Beer>();
    }

    public void AddBeer(Beer beer)
    {
        beers.Add(beer); 
    }

    public List<string> ListBeers()
    {
        List<string> beerDescriptions = new List<string>();
        foreach (var beer in beers)
        {
            beerDescriptions.Add(beer.ToString()); 
        }
        return beerDescriptions;
    }
}


class Program
{
    static void Main(string[] args)
    {
        
        Brewery brewery = new Brewery("Craft Brewery");

        
        Lager lager = new Lager("Golden Lager", 5.0, 15);
        Ale ale = new Ale("Dark Ale", 6.5, "Dark Brown");

       
        brewery.AddBeer(lager);
        brewery.AddBeer(ale);

        
        Console.WriteLine($"Brewery: {brewery.Name}");
        foreach (var beerDescription in brewery.ListBeers())
        {
            Console.WriteLine(beerDescription);
        }
    }
}
