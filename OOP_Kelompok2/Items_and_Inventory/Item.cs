namespace OOP_Kelompok2
{
    public class Potion : IItem
    {
        public string Name => "Potion";
        public string Description => "Restores 50 Health.";

        public void Use(Player player)
        {
            player.Heart += 50;
            Console.WriteLine($"{Name} used. {player.Name}'s Health restored by 50.");
        }
    }

    public class HappyCandy : IItem
    {
        public string Name => "Happy Candy";
        public string Description => "Makes you happy. Increases Defense but reduces Accuracy.";

        public void Use(Player player)
        {
            player.Defense += 10;
            player.HitRate -= 5;
            Console.WriteLine($"{Name} used. {player.Name}'s Defense increased, but Accuracy decreased.");
        }
    }
}
