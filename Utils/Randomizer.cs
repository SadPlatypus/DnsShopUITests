namespace DnsShopUITests.Utils
{
    internal class Randomizer
    {
        private Random random = new Random();
        public int GetRandomInt(int range)
        {
            return random.Next(range);
        }
    }
}
