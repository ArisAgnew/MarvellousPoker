namespace MarvellousPoker.Models.Abstractions
{
    public interface IHand
    {
        ReadOnlyCollection<Card> Cards { get; }

        PokerHandRank FinalHand { get; set; }

        event EventHandler HandChanged;

        //TODO 01/15/2022 get on with it...
    }
}
