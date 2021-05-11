using MarvellousPoker.Controllers.Adjuvants;

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

        public void Deconstruct(out Rank rank, out Suit suit) => (rank, suit) = _compoundCard;
    }
}
