namespace MarvellousPoker.Models
{
    public enum Suit : byte
    {
        [Description("\u2666")] DIAMOND = 0x01,
        [Description("\u2665")] HEART = 0x02,
        [Description("\u2663")] CLUB = 0x03,
        [Description("\u2660")] SPADE = 0x04
    }
}
