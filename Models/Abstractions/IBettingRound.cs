namespace MarvellousPoker.Models.Abstractions
{
    public interface IBettingRound
    {
        event EventHandler DealOut;
        event EventHandler PreFlop;
        event EventHandler Flop;
        event EventHandler Turn;
        event EventHandler River;
        event EventHandler ShowDown;

        IPlayer AssignASmallBlind(decimal value = default);
        IPlayer AssignABigBlind(decimal value = default);
    }
}
