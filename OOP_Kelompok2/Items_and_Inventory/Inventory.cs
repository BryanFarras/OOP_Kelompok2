namespace OOP_Kelompok2
{
    public interface IItem
    {
        string Name { get; }
        string Description { get; }
        void Use(Player player);
    }
    
    public class Inventory
    {
        private List<IItem> _items = new List<IItem>();

        public void AddItem(IItem item)
        {
            _items.Add(item);
            Console.WriteLine($"{item.Name} added to inventory.");
        }

        public void UseItem(int index, Player player)
        {
            if (index < 0 || index >= _items.Count)
            {
                Console.WriteLine("Invalid item selection.");
                return;
            }

            IItem item = _items[index];
            item.Use(player);
            _items.RemoveAt(index);
            Console.WriteLine($"{item.Name} removed from inventory after use.");
        }

        public void DisplayInventory()
        {
            Console.WriteLine("\n=== Inventory ===");
            for (int i = 0; i < _items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. { _items[i].Name} - { _items[i].Description}");
            }
        }
    }
}
