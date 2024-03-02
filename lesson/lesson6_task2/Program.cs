using System;
using System.Collections.Generic;

public abstract class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Intelligence { get; set; }

    public Character(string name, int health, int strength, int agility, int intelligence)
    {
        Name = name;
        Health = health;
        Strength = strength;
        Agility = agility;
        Intelligence = intelligence;
    }

    public abstract void Attack(Character target);
    public abstract void TakeDamage(int damage);
}

public class Warrior : Character
{
    public Warrior(string name, int health, int strength, int agility, int intelligence) : base(name, health, strength, agility, intelligence)
    {
    }

    public override void Attack(Character target)
    {
        int damage = Strength / 2;
        target.TakeDamage(damage);
    }

    public override void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} takes {damage} damage.");
    }
}

public class Mage : Character
{
    public Mage(string name, int health, int strength, int agility, int intelligence) : base(name, health, strength, agility, intelligence)
    {
    }

    public override void Attack(Character target)
    {
        int damage = Intelligence / 2;
        target.TakeDamage(damage);
    }

    public override void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} takes {damage} damage.");
    }
}

public class Rogue : Character
{
    public Rogue(string name, int health, int strength, int agility, int intelligence) : base(name, health, strength, agility, intelligence)
    {
    }

    public override void Attack(Character target)
    {
        int damage = Agility / 2;
        target.TakeDamage(damage);
    }

    public override void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} takes {damage} damage.");
    }
}

public class CharacterObserver
{
    private List<Character> characters = new List<Character>();

    public void AddCharacter(Character character)
    {
        characters.Add(character);
    }

    public void RemoveCharacter(Character character)
    {
        characters.Remove(character);
    }

    public void Update()
    {
        foreach (Character character in characters)
        {
            Console.WriteLine($"{character.Name} has {character.Health} health, {character.Strength} strength, {character.Agility} agility, and {character.Intelligence} intelligence.");
        }
    }
}

class Program
{
    static void Main()
    {
        CharacterObserver observer = new CharacterObserver();

        Warrior warrior = new Warrior("Warrior", 100, 20, 10, 5);
        Mage mage = new Mage("Mage", 80, 10, 15, 20);
        Rogue rogue = new Rogue("Rogue", 60, 15, 20, 10);

        observer.AddCharacter(warrior);
        observer.AddCharacter(mage);
        observer.AddCharacter(rogue);

        Console.WriteLine("Initial state:");
        observer.Update();

        warrior.Attack(mage);
        Console.WriteLine("After attack:");
        observer.Update();

        mage.TakeDamage(10);
        Console.WriteLine("After taking damage:");
        observer.Update();

        observer.RemoveCharacter(rogue);
        Console.WriteLine("After removing rogue:");
        observer.Update();
    }
}