namespace MarvellousPoker.Models.Abstractions
{
    public record PokerHandMatchedArgs
    {
        public PokerHandRank? PokerHand { get; init; }

        public PokerHandMatchedArgs() { }

        public PokerHandMatchedArgs(PokerHandRank pokerHand) =>
            PokerHand = pokerHand.MightBeNullOrDefault(nameof(PokerHandRank));

        public void Deconstruct(out PokerHandRank? pokerHand) => pokerHand = PokerHand;
    }

    //Decorator
    public abstract class HandController
    {
        private const sbyte BOUNDARY = 10;

        private protected EventHandler<PokerHandMatchedArgs>[] eventHandler =
            new EventHandler<PokerHandMatchedArgs>[BOUNDARY];

        private PokerHandRank _pokerHandRank;

        private protected PokerHandMatchedArgs matchedArgs;

        public virtual Guid PokerHandGuid { get; private init; }

        public PokerHandRank PokerHandRank
        {
            get
            {
                return _pokerHandRank;
            }
            set
            {
                if (_pokerHandRank != value)
                {
                    _pokerHandRank = value;
                    matchedArgs = new(value);

                    for (int i = 0; i < BOUNDARY; ++i)
                    {
                        eventHandler[i].SafeEvoke(this, matchedArgs);
                    }
                }
            }
        }

        public event EventHandler<PokerHandMatchedArgs> PokerHandMatched
        {
            add
            {
                sbyte i;

                for (i = 0; i < BOUNDARY; ++i)
                {
                    if (eventHandler[i] is null)
                    {
                        eventHandler[i] = value;
                        break;
                    }
                }

                if (i == BOUNDARY)
                {
                    Console.WriteLine($"Event list is full: {i}.");
                }
            }
            //use only with method-based handlers!
            remove
            {
                sbyte i;

                for (i = 0; i < BOUNDARY; ++i)
                {
                    if (eventHandler[i] == value)
                    {
                        eventHandler[i] = null;
                        break;
                    }
                }

                if (i == BOUNDARY)
                {
                    Console.WriteLine($"Handler was not found.");
                }
            }
        }

        public HandController(Guid guid)
        {
            PokerHandGuid = guid.MightBeNullOrDefault();
        }

        public abstract GameState CommitHand();
    }

    public class PokerHandRegularClass : HandController
    {
        // huge switch + Player's hand incoming

        public PokerHandRank RankMatched { get; } = PokerHandRank.ROYAL_FLUSH; //matched

        /*public virtual PokerHandRank RoyalFlush { get; init; }
        public virtual PokerHandRank StraightFlush { get; init; }
        public virtual PokerHandRank FourOfAKindFlush { get; init; }
        public virtual PokerHandRank FullHouse { get; init; }
        public virtual PokerHandRank Flush { get; init; }
        public virtual PokerHandRank Straight { get; init; }
        public virtual PokerHandRank ThreeOfAKind { get; init; }
        public virtual PokerHandRank TwoPair { get; init; }
        public virtual PokerHandRank HighHand { get; init; }*/

        public PokerHandRegularClass(Guid guid) : base(guid) { } // smth else

        public override GameState CommitHand()
        {
            PokerHandRank = RankMatched;
            return new GameState();
        }
    }
}
