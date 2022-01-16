namespace MarvellousPoker.Models
{
    [Flags]
    public enum GameAction : byte
    {
        DEALOUT = 0x00,
        PREFLOP = 0x01,
        FLOP = 0x02,
        TURN = 0x04,
        RIVER = 0x08,
        SHOWDOWN = 0x10
    }
}
