namespace OOP_Kelompok2
{
    public class ItemDecorator : IItem
    {
        protected IItem _baseItem;

        public ItemDecorator(IItem baseItem)
        {
            _baseItem = baseItem;
        }

        public virtual string Name => _baseItem.Name;
        public virtual string Description => _baseItem.Description;

        public virtual void Use(Player player)
        {
            _baseItem.Use(player);
        }
    }

    public class AttackBoostDecorator : ItemDecorator
    {
        public AttackBoostDecorator(IItem baseItem) : base(baseItem) { }

        public override string Description => _baseItem.Description + " Also boosts Attack temporarily.";

        public override void Use(Player player)
        {
            base.Use(player);
            player.Attack += 10;
            Console.WriteLine($"Attack boosted temporarily by 10.");
        }
    }

    public class EmotionChangerDecorator : ItemDecorator
    {
        private string _emotion;

        public EmotionChangerDecorator(IItem baseItem, string emotion) : base(baseItem)
        {
            _emotion = emotion;
        }

        public override string Description => _baseItem.Description + $" Changes player's emotion to {_emotion}.";

        public override void Use(Player player)
        {
            base.Use(player);
            Console.WriteLine($"Player's emotion changed to {_emotion}.");
        }
    }
}
