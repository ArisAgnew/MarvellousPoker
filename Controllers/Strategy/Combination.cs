namespace MarvellousPoker.Controllers.Strategy
{
    public struct Combination
    {
        public struct RoyalFlush : ICombination
        {
            public bool CheckUp(IReadOnlyCollection<Card> handCards)
            {
                throw new NotImplementedException();
            }
        }

        public struct StraightFlush : ICombination
        {
            public bool CheckUp(IReadOnlyCollection<Card> handCards)
            {
                throw new NotImplementedException();
            }
        }

        public struct FourOfAkind : ICombination
        {
            public bool CheckUp(IReadOnlyCollection<Card> handCards)
            {
                (Rank, Suit)[] tens = new (Rank, Suit)[]
                {
                    (Rank.TEN, Suit.CLUB),
                    (Rank.TEN, Suit.SPADE),
                    (Rank.TEN, Suit.DIAMOND),
                    (Rank.TEN, Suit.HEART),
                };

                (Rank, Suit)[] queens = new (Rank, Suit)[]
                {
                    (Rank.QUEEN, Suit.CLUB),
                    (Rank.QUEEN, Suit.SPADE),
                    (Rank.QUEEN, Suit.DIAMOND),
                    (Rank.QUEEN, Suit.HEART),
                };

                IEnumerable<(Rank RankValue, Suit SuitValue)> GetDuplicates(PokerHandRank rank,
                                IDictionary<PokerHandRank, IEnumerable<(Rank RankValue, Suit SuitValue)>> dict,
                                IEnumerable<(Rank RankValue, Suit SuitValue)> keysToLook)
                {
                    return dict[rank]
                        .Intersect(keysToLook)
                        .GroupBy(i => i)
                        .Where(g => g.Count() == keysToLook.Count())
                        .Select(g => g.Key)
                        .AsEnumerable();
                }

                Dictionary<PokerHandRank, IEnumerable<(Rank RankValue, Suit SuitValue)>> dict = new()
                {
                    {
                        PokerHandRank.FOUR_OF_A_KIND,
                        new (Rank, Suit)[]
                        {
                            (Rank.QUEEN, Suit.CLUB),
                            (Rank.QUEEN, Suit.SPADE),
                            (Rank.QUEEN, Suit.DIAMOND),
                            (Rank.QUEEN, Suit.HEART),
                        }
                    }
                };

                /*GetDuplicates(PokerHandRank.FOUR_OF_A_KIND, dict, handCards.Select(c => c.CompoundCard))
                    .ToList().ForEach(r => Console.WriteLine(r));*/

                var comparator = new CardComparer();

                /*                dict[PokerHandRank.FOUR_OF_A_KIND]
                                    .Intersect(handCards.Select(c => c.CompoundCard))
                                    .GroupBy(i => i)
                                    //.Where(g => g.Count() == dict[PokerHandRank.FOUR_OF_A_KIND].Count())
                                    .Select(g => g.Key)
                                    .ToList().ForEach(r => Console.WriteLine(r));*/

                /*Console.WriteLine(dict[PokerHandRank.FOUR_OF_A_KIND]
                    .Intersect(handCards
                        .GroupBy(i => i, comparator)
                        .Select(g => g.Key)
                        .Select(c => c.CompoundCard)
                        .AsEnumerable())
                    .GroupBy(i => i)
                    .Select(g => new 
                    {
                        Tuple = g.Key,
                        Count = g.Count(),
                        RankValue = g.Select(rv => rv.RankValue),
                        SuitValue = g.Select(sv => sv.RankValue)
                    })
                    
                    
                    );*/

                var probeList = dict[PokerHandRank.FOUR_OF_A_KIND]
                    .Intersect(handCards.Select(c => c.CompoundCard));

                var fromGroup = probeList
                    .GroupBy(i => i)
                    .Where(_ => probeList.Count() == 4)
                    .Select(g => new
                    {
                        Tuple = g.Key,
                        RankValues = g.Select(rv => rv.RankValue),
                        SuitValues = g.Select(sv => sv.SuitValue)
                    });

                foreach (var group in fromGroup)
                {
                    Console.WriteLine($"Count: {group.Tuple}");
                    foreach (var rank in group.RankValues)
                    {
                        foreach (var suit in group.SuitValues)
                        {
                            Console.WriteLine($"{rank} & {suit}");
                        }
                    }
                }

                /*var edited = handCards
                    .Cast<Card>()
                    .Select(c => c.CompoundCard)
                    .Cast<(Rank, Suit)>()
                    .Intersect(tens)
                    .SelectMany(tuple =>
                    {
                        var collection = new List<(Rank, Suit)>() { tuple };
                        return collection.Any()
                            ? collection
                            : Enumerable.Empty<(Rank, Suit)>();
                    });

                var newList = edited.Where(_ => edited.Count() == 4).Select(t => t);


                Console.WriteLine($"Size? {newList.Count()}");

                newList.ToList().ForEach(h => Console.WriteLine($"Result: {h}"));

                Console.WriteLine($"4 cards?: {newList.Count() == 4}");*/

                return true;
            }
        }

        public struct FullHouse : ICombination
        {
            public bool CheckUp(IReadOnlyCollection<Card> handCards)
            {
                throw new NotImplementedException();
            }
        }

        public struct Flush : ICombination
        {
            public bool CheckUp(IReadOnlyCollection<Card> handCards)
            {
                throw new NotImplementedException();
            }
        }

        public struct Straight : ICombination
        {
            public bool CheckUp(IReadOnlyCollection<Card> handCards)
            {
                throw new NotImplementedException();
            }
        }

        public struct ThreeOfAKind : ICombination
        {
            public bool CheckUp(IReadOnlyCollection<Card> handCards)
            {
                throw new NotImplementedException();
            }
        }

        public struct TwoPair : ICombination
        {
            public bool CheckUp(IReadOnlyCollection<Card> handCards)
            {
                throw new NotImplementedException();
            }
        }

        public struct OnePair : ICombination
        {
            public bool CheckUp(IReadOnlyCollection<Card> handCards)
            {
                throw new NotImplementedException();
            }
        }

        public struct HighHand : ICombination
        {
            public bool CheckUp(IReadOnlyCollection<Card> handCards)
            {
                throw new NotImplementedException();
            }
        }
    }
}
