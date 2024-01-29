using System;
using System.Collections.Generic;

class Program
{
    static int playerHealth = 100;
    static int playerDamage = 20;
    static List<string> playerInventory = new List<string>();

    static void Main()
    {
        Console.WriteLine("Welcome to the Adventure Game!");

        Console.Write("Enter your character's nickname: ");
        string nickname = Console.ReadLine();

        Console.WriteLine($"Welcome, {nickname}! Choose your character type:");
        Console.WriteLine("1. Warrior");
        Console.WriteLine("2. Mage");

        int characterChoice = GetChoice(1, 2);

        string characterType = (characterChoice == 1) ? "Warrior" : "Mage";
        Console.WriteLine($"You chose to be a {characterType}!");

        Console.WriteLine("You embark on a journey in a mysterious forest...");

        while (playerHealth > 0)
        {
            Console.WriteLine($"\nHealth: {playerHealth} | Damage: {playerDamage} | Inventory: {string.Join(", ", playerInventory)}");
            Console.WriteLine("You find yourself at a crossroad. Choose your path:");
            Console.WriteLine("1. Take the left path");
            Console.WriteLine("2. Take the right path");

            int pathChoice = GetChoice(1, 2);

            switch (pathChoice)
            {
                case 1:
                    LeftPath(characterType);
                    break;
                case 2:
                    RightPath(characterType);
                    break;
            }
        }

        Console.WriteLine("Game over! Your journey has come to an end.");
    }

    static void LeftPath(string characterType)
    {
        Console.WriteLine("You venture down the left path...");

        Console.WriteLine("You encounter a bear! What will you do?");
        Console.WriteLine("1. Fight the bear");
        Console.WriteLine("2. Try to scare it away");

        int actionChoice = GetChoice(1, 2);

        if (actionChoice == 1)
        {
            Console.WriteLine($"You bravely fight the bear as a {characterType}!");
            Battle("Bear", 70, 15);
        }
        else
        {
            Console.WriteLine($"You attempt to scare the bear away as a {characterType}!");
            int scareChance = new Random().Next(1, 11); // 10% chance
            if (scareChance == 1)
            {
                Console.WriteLine("You successfully scare away the bear!");
            }
            else
            {
                Console.WriteLine("The bear is not scared and attacks you!");
                Battle("Bear", 70, 15);
            }
        }
    }

    static void RightPath(string characterType)
    {
        Console.WriteLine("You venture down the right path...");

        Console.WriteLine("You encounter a pack of wolves! What will you do?");
        Console.WriteLine("1. Fight the wolves");
        Console.WriteLine("2. Try to sneak past them");

        int actionChoice = GetChoice(1, 2);

        if (actionChoice == 1)
        {
            Console.WriteLine($"You bravely fight the wolves as a {characterType}!");
            Battle("Wolves", 40, 15);
        }
        else
        {
            Console.WriteLine($"You attempt to sneak past the wolves as a {characterType}!");
            int sneakChance = new Random().Next(1, 11); // 10% chance
            if (sneakChance == 1)
            {
                Console.WriteLine("You successfully sneak past the wolves!");
            }
            else
            {
                Console.WriteLine("The wolves notice you, and you have to face them!");
                Battle("Wolves", 40, 15);
            }
        }
    }

    static void Battle(string enemyName, int enemyHealth, int enemyDamage)
    {
        while (playerHealth > 0 && enemyHealth > 0)
        {
            Console.WriteLine($"\n{enemyName} Health: {enemyHealth} | Your Health: {playerHealth}");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Defend");

            int battleChoice = GetChoice(1, 2);

            switch (battleChoice)
            {
                case 1:
                    Console.WriteLine($"You attack the {enemyName}!");
                    enemyHealth -= playerDamage;

                    Console.WriteLine($"{enemyName} attacks you!");
                    playerHealth -= enemyDamage;
                    break;
                case 2:
                    Console.WriteLine($"You defend against {enemyName}'s attack!");
                    playerHealth -= (enemyDamage / 2);
                    break;
            }
        }

        if (playerHealth <= 0)
        {
            Console.WriteLine($"You were defeated by the {enemyName}. Game over!");
        }
        else
        {
            Console.WriteLine($"You defeated the {enemyName}!");

            int chance = new Random().Next(1, 11); // 10% chance
            if (chance == 1)
            {
                string[] collectableItems = { "Sword", "Armor" };
                string foundItem = collectableItems[new Random().Next(collectableItems.Length)];
                Console.WriteLine($"You found a {foundItem} after defeating the {enemyName}!");
                playerInventory.Add(foundItem);
            }
        }
    }

    static void ExploreShack()
    {
        Console.WriteLine("You enter an abandoned shack...");

        Console.WriteLine("You find a health potion in the shack. Drink it?");
        Console.WriteLine("1. Drink the potion");
        Console.WriteLine("2. Leave the potion");

        int potionChoice = GetChoice(1, 2);

        if (potionChoice == 1)
        {
            Console.WriteLine("You drink the health potion and restore some health!");
            playerHealth += 30; // You can adjust the amount restored
        }
        else
        {
            Console.WriteLine("You choose to leave the health potion behind.");
        }

        int chance = new Random().Next(1, 11); // 10% chance
        if (chance == 1)
        {
            string[] collectableItems = { "Sword", "Armor" };
            string foundItem = collectableItems[new Random().Next(collectableItems.Length)];
            Console.WriteLine($"You found a {foundItem} in the shack!");
            playerInventory.Add(foundItem);
        }
    }

    static void ExploreCave()
    {
        Console.WriteLine("You enter a dark cave...");

        Console.WriteLine("You discover two tunnels inside the cave. Choose one:");
        Console.WriteLine("1. Go left");
        Console.WriteLine("2. Go right");

        int tunnelChoice = GetChoice(1, 2);

        switch (tunnelChoice)
        {
            case 1:
                Console.WriteLine("You find a hidden treasure chest!");
                // Implement finding a valuable item or gold in the left tunnel
                break;
            case 2:
                Console.WriteLine("You encounter a giant spider!");
                Battle("Spider", 60, 20);
                break;
        }
    }

    static int GetChoice(int min, int max)
    {
        int choice;
        while (true)
        {
            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= min && choice <= max)
            {
                break;
            }
            else
            {
                Console.WriteLine($"Invalid input. Please enter a number between {min} and {max}.");
            }
        }
        return choice;
    }
}
