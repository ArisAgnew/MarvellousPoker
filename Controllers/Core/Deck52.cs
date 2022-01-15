using MarvellousPoker.Controllers.Adjuvants;
using MarvellousPoker.Meta.CustomExceptions;
using MarvellousPoker.Models;
using MarvellousPoker.Models.Abstractions;

using static System.Enum;
using static System.Guid;
using static System.Linq.Enumerable;

namespace MarvellousPoker.Controllers.Core
{
    public sealed class Deck52 : IDeck, IDefaultDeck<Card>, IEquatable<Deck52>
    {
        private static readonly ushort FIFTY_TWO = 52;

        private readonly List<Card> _cards = new(FIFTY_TWO);

        private int cardIndex;

        public ReadOnlyCollection<Card> Cards => _cards?.AsReadOnly();

        public Guid Deck52Guid { get; private init; }

        internal ImmutableList<Card> CardsAsImmutableList => _cards?.ToImmutableList();

        internal IImmutableQueue<Card> CardsAsImmutableQueue => ImmutableQueue.CreateRange(_cards ?? Empty<Card>());

        internal IImmutableStack<Card> CardsAsImmutableStack => ImmutableStack.CreateRange(_cards ?? Empty<Card>());

        private Func<List<Card>, List<Card>> GetDeck52 => collection =>
        {
            List<Card> cardList = collection.OughtToBeEmpty().Cast<Card>() as List<Card>;
            cardList.AddRange(GetBrandNewDeck());
            return cardList;
        };

        public Deck52()
        {
            Deck52Guid = NewGuid();
            Deal();
            cardIndex = _cards.Count;
        }

        //Shuffled deck
        public IDeck Deal()
        {
            Shuffle(GetDeck52(_cards));
            return this;
        }

        public IReadOnlyCollection<Card> GetBrandNewDeck() => GetValues<Rank>()
            .SelectMany(RankValue => GetValues<Suit>().Select(SuitValue => (RankValue, SuitValue)))
            .Select(tuple => new Card(tuple))
            .ToImmutableList();

        //Beta
        public Card GetNextCard()
        {
            switch (cardIndex)
            {
                case int index when index is not default(int) and > 0:
                    --cardIndex;
                    var card = _cards[cardIndex];
                    return card;
                default: throw new GameGeneralException("The deck has no cards of any kind."); break;
            }
        }

        //Unshuffled deck
        public IDeck Restore()
        {
            GetDeck52(_cards);
            return this;
        }

        public void Shuffle<T>(ICollection<T> collection) where T : notnull
        {
            for (int i = default; i < collection.Count; ++i)
            {
                var index = new Random().Next(0, collection.Count);
                var temp = _cards[i];
                _cards[i] = _cards[index];
                _cards[index] = temp;
            };
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Deck52);
        }

        public bool Equals(Deck52 other)
        {
            return other != null &&
                   EqualityComparer<List<Card>>.Default.Equals(_cards, other._cards) &&
                   EqualityComparer<ReadOnlyCollection<Card>>.Default.Equals(Cards, other.Cards) &&
                   Deck52Guid.Equals(other.Deck52Guid) &&
                   EqualityComparer<IImmutableList<Card>>.Default.Equals(CardsAsImmutableList, other.CardsAsImmutableList) &&
                   EqualityComparer<IImmutableQueue<Card>>.Default.Equals(CardsAsImmutableQueue, other.CardsAsImmutableQueue) &&
                   EqualityComparer<IImmutableStack<Card>>.Default.Equals(CardsAsImmutableStack, other.CardsAsImmutableStack) &&
                   EqualityComparer<Func<List<Card>, List<Card>>>.Default.Equals(GetDeck52, other.GetDeck52);
        }

        public static bool operator ==(Deck52 left, Deck52 right)
        {
            return EqualityComparer<Deck52>.Default.Equals(left, right);
        }

        public static bool operator !=(Deck52 left, Deck52 right)
        {
            return !(left == right);
        }

        public override int GetHashCode() => this.GetHashCode(_cards);
    }
}
