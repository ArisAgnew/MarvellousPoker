namespace MarvellousPoker.Models.Abstractions
{
    public interface IPlayer
    {
        string Name { get; init; }

        decimal BuyIn { get; init; }

        decimal Balance { get; set; }

        decimal MakeABet { get; set; }

        IHand Hand { get; set; }
    }
}
