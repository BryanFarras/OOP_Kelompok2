using System;

namespace OOP_Kelompok2
{
    class Story
    {
        public static void Intro(Player player)
        {
            Console.WriteLine("...");
            Console.WriteLine("You find yourself standing in a vast, empty field, shrouded in mist.");
            Console.WriteLine("The air is thick and heavy, and something feels... off.");
            Console.WriteLine($"{player.Name}, you feel a deep unease settle in your chest.");
            Console.WriteLine("In the distance, you see a faint light flickering. It calls to you.");

            Console.WriteLine("\nChoose your action:");
            Console.WriteLine("1. Approach the light");
            Console.WriteLine("2. Ignore it and walk in the opposite direction");

            string? choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("\nYou decide to follow the light.");
                Console.WriteLine("As you get closer, you realize it's a lantern hanging by an old, twisted tree.");
                Console.WriteLine("A voice, faint yet clear, calls out to you: 'Are you lost?'");

                // Branching consequences
                Console.WriteLine("\nChoose your response:");
                Console.WriteLine("1. 'Yes, I don't know where I am.'");
                Console.WriteLine("2. 'No, I know exactly where I’m going.'");

                string? response = Console.ReadLine();

                if (response == "1")
                {
                    Console.WriteLine("\nThe voice softens: 'Then let me guide you.'");
                    Console.WriteLine("The tree offers you a branch with a glowing orb. Your heart feels warmer, gaining 10 points.");
                    player.Heart += 10;
                }
                else if (response == "2")
                {
                    Console.WriteLine("\nThe voice grows distant: 'Then you don’t need me...'");
                    Console.WriteLine("The light dims, leaving you in darkness. You feel a chill as your heart loses 5 points.");
                    player.Heart -= 5;
                }
                else
                {
                    Console.WriteLine("\nThe silence answers back. You stand alone, unmoved by the tree.");
                }
            }
            else if (choice == "2")
            {
                Console.WriteLine("\nYou turn away from the light and walk into the mist.");
                Console.WriteLine("The darkness thickens around you, swallowing up your steps. You begin to feel lost, unsure of what lies ahead.");

                Console.WriteLine("\nChoose your action:");
                Console.WriteLine("1. Keep moving forward");
                Console.WriteLine("2. Stop and try to retrace your steps");

                string? secondChoice = Console.ReadLine();

                if (secondChoice == "1")
                {
                    Console.WriteLine("\nYou press on, determined not to stop.");
                    Console.WriteLine("Suddenly, a shadowy figure emerges in front of you, its eyes glowing with a faint red light.");
                    Console.WriteLine("It snarls, ready to attack!");
                    Console.WriteLine("Prepare for combat...");
                }
                else if (secondChoice == "2")
                {
                    Console.WriteLine("\nYou try to retrace your steps, but the mist has obscured your path.");
                    Console.WriteLine("You feel the weight of loneliness settling in. Just as you’re about to give up, you hear footsteps.");
                    Console.WriteLine("A mysterious figure appears, and you feel a strange sense of connection.");
                    Console.WriteLine("This may be an ally or a foe...");
                }
                else
                {
                    Console.WriteLine("\nYou stand still, unsure of what to do. The mist closes in around you.");
                }
            }
            else
            {
                Console.WriteLine("\nYour indecision leaves you rooted in place, surrounded by silence.");
            }
        }
    }
}
1