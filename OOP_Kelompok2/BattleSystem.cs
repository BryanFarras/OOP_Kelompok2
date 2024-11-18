namespace OOP_Kelompok2
{
    public class BattleSystem
    {
        private IAttackStrategy? _attackStrategy;

        public void SetAttackStrategy(IAttackStrategy attackStrategy)
        {
            _attackStrategy = attackStrategy;
        }

        public void ExecuteStrategy(Player player, Enemy enemy)
        {
            if (_attackStrategy == null)
            {
                Console.WriteLine("No attack strategy selected!");
                return;
            }

            _attackStrategy.Execute(player, enemy);
        }
    }
}
