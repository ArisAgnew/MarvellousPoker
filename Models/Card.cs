namespace MarvellousPoker.Models
{
    public class Card
    {
        private Rank _rank;
        private Suit _suit;

        private readonly (Rank RankValue, Suit SuitValue) _compoundCard;

        public Rank Rank
        {
            get => _compoundCard.RankValue;
            set
            {
                if (_rank != _compoundCard.RankValue)
                {
                    _rank = _compoundCard.RankValue;

                    if (_rank != value)
                    {
                        _rank = value;
                    }
                }
            }
        }

        public Suit Suit
        {
            get => _compoundCard.SuitValue;
            set
            {
                if (_suit != _compoundCard.SuitValue)
                {
                    _suit = _compoundCard.SuitValue;

                    if (_suit != value)
                    {
                        _suit = value;
                    }
                }
            }
        }

        public (Rank RankValue, Suit SuitValue) CompoundCard
        {
            get => _compoundCard;
            init
            {
                if (_compoundCard != value)
                {
                    _compoundCard = value;
                }
            }
        }

        public Card(Rank rank, Suit suit) => _compoundCard = (rank, suit).MightBeNullOrDefault();
        public Card((Rank rank, Suit suit) singleCardAsTuple) => _compoundCard = singleCardAsTuple.MightBeNullOrDefault();

        public void Deconstruct(out Rank rank, out Suit suit) => (rank, suit) = _compoundCard;

        public override int GetHashCode() => this.GetHashCode<Card, (Rank, Suit)>(CompoundCard);

        /*public override bool Equals(object obj)
        {
            return obj is Card card &&
                   _rank == card._rank &&
                   _suit == card._suit &&
                   _compoundCard.Equals(card._compoundCard) &&
                   Rank == card.Rank &&
                   Suit == card.Suit &&
                   CompoundCard.Equals(card.CompoundCard);
        }*/
    }

    public class CardComparer : IEqualityComparer<Card>
    {
        public bool Equals(Card x, Card y)
        {
            //Check whether the compared objects reference the same data.
            if (ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (x is null || y is null)
                return false;

            //Check whether the products' properties are equal.
            return x.Rank == y.Rank && x.Suit == y.Suit;
        }

        public int GetHashCode([DisallowNull] Card obj) =>
            obj.GetHashCodeCombined<Card, (Rank, Suit)>(obj.CompoundCard);
    }
}
