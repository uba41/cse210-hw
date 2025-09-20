using System;

using System.Collections.Generic;

using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Person p1 = new Person();
        p1._firstName = "Uba";
        p1._lastName = "Ugwu";
        p1._age = 20;

        Person p2 = new Person();
        p2._firstName = "John";
        p2._lastName = "Doe";
        p2._age = 30;

        List<Person> people  = new List<Person>();
        people.Add(p1);
        people.Add(p2);

        foreach (Person p in people)
        {
            Console.WriteLine(p._firstName);
        }

        // SaveToFile(people);

        List<Person> newPeople = ReadFromFile();
        foreach (Person p in newPeople)
        {
            Console.WriteLine(p._firstName);
        }

    }

    public static void SaveToFile(List<Person>people)
    {
        Console.WriteLine("Saving to file...");
        string filename = "people.txt";

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
        
            foreach (Person p in people)
            {
            outputFile.WriteLine($"{p._firstName}-{p._lastName}-{p._age}");
            }
        }    
    }

    public static List<Person>ReadFromFile()
    {
        Console.WriteLine("Reading list from file...");
        List<Person> people = new List<Person>();
        string filename = "people.txt";

        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            //Console.WriteLine(Line);
            // line wiil have something like ubap-Ugwu-20
            string[] parts = line.Split("-");

            //part[0] = first name
            //part[1] = last name
            //part[2] = age

            Person newPeople = new Person();
            newPeople._firstName = parts[0];
            newPeople._lastName = parts[1];
            newPeople._age = int.Parse(parts[2]);

            people.Add(newPeople);
        }

        return people;
    }
}