namespace MarvellousPoker.Models
{
    [Flags]
    public enum GameAction : ushort
    {
        DEALOUT = 0,
        PREFLOP = 1,
        FLOP = 2,
        TURN = 4,
        RIVER = 8,
        SHOWDOWN = 16
    }
}
