namespace MarvellousPoker.Models.Abstractions
{
    public interface IPokerRunning
    {
        IPlayer Bet();
        IPlayer Call();
        IPlayer Raise();
        IPlayer Cheque();
        IPlayer Fold();
    }
}
