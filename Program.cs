using System.Collections.Immutable;
using MarvellousPoker.Controllers.Adjuvants;
using MarvellousPoker.Controllers.Core;
using MarvellousPoker.Controllers.Strategy;
using MarvellousPoker.Meta.CustomExceptions;
using MarvellousPoker.Models;
using MarvellousPoker.Models.Abstractions;

namespace MarvellousPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            /*IDeck deck = new Deck52();

            (deck as Deck52).GetBrandNewDeck().ToImmutableList().ForEach(card =>
                    Console.WriteLine($"Card: {card.Rank.GetDescriptionValue().NumberValue}" +
                    $"{card.Suit.GetDescriptionValue().StringValue}"));*/

            foreach (Rank name in (Rank[])Enum.GetValues(typeof(Rank)))
            {
                WriteLine(name);
            }

            Console.ReadLine();

            try
            {
                throw new GameGeneralException("Something", new Exception("Inner Here"));
            }
            catch (GameGeneralException e)
            {
                Console.WriteLine(e.GameExceptionMessage);
                Console.WriteLine(e.InnerException.Message);
            }

            /*IDeck deck = new Deck52();

            (deck as Deck52).GetBrandNewDeck().ToImmutableList().ForEach(card =>
                    Console.WriteLine($"Card: {card.Rank.GetDescriptionValue().StringValue}" +
                    $"{card.Suit.GetDescriptionValue().StringValue}"));

            Console.WriteLine("==-=-=-=-=");

            (deck as Deck52).CardsAsImmutableList.ForEach(card =>
                    Console.WriteLine($"Card: {card.Rank.GetDescriptionValue().StringValue}" +
                    $"{card.Suit.GetDescriptionValue().StringValue}"));

            Console.WriteLine(deck.Cards.Count());
            Console.WriteLine((deck as Deck52).GetHashCode());*/

            /*HandController pokerHand = new PokerHandRegularClass(default);

            void ProbeHandler(object sender, PokerHandMatchedArgs e)
            {
                Console.WriteLine("PROBE1*");
            }

            pokerHand.PokerHandMatched += ProbeHandler;
            pokerHand.PokerHandMatched += (_, e) => Console.WriteLine("PROBE2");
            pokerHand.PokerHandMatched += (_, e) => Console.WriteLine("PROBE3");

            pokerHand.PokerHandMatched -= ProbeHandler;
            pokerHand.CommitHand();

            Console.WriteLine(pokerHand.PokerHandRank.GetDescriptionValue());*/

            IEnumerable<Card> iCards = new List<Card>()
            {
                new Card(Rank.TEN, Suit.DIAMOND),
                new Card(Rank.JACK, Suit.DIAMOND),
                new Card(Rank.QUEEN, Suit.DIAMOND),
                new Card(Rank.KING, Suit.DIAMOND),
                new Card(Rank.ACE, Suit.DIAMOND)
            }.AsReadOnly();

            LinkedList<Card> linkedCards = new(iCards);
            /*var first = linkedCards.AddFirst(new Card(Rank.TEN, Suit.DIAMOND));
            var second = linkedCards.AddAfter(first, new Card(Rank.JACK, Suit.DIAMOND));
            var third = linkedCards.AddAfter(second, new Card(Rank.QUEEN, Suit.DIAMOND));
            var fourth = linkedCards.AddAfter(third, new Card(Rank.KING, Suit.DIAMOND));
            var fifth = linkedCards.AddAfter(fourth, new Card(Rank.ACE, Suit.DIAMOND));*/

            foreach (var card in linkedCards)
            {
                Console.WriteLine($"{card.Rank} {card.Suit}");
            }

            Console.WriteLine(linkedCards.First.Value.CompoundCard);
            Console.WriteLine(linkedCards.First.Value.Rank);
            Console.WriteLine(linkedCards.First.Value.Suit);
            Console.WriteLine();
            Console.WriteLine(linkedCards.Last.Value.CompoundCard);
            Console.WriteLine(linkedCards.Last.Value.Rank);
            Console.WriteLine(linkedCards.Last.Value.Suit);

            var cardsFourOfAKind = new List<Card>()
            {
                new Card(Rank.QUEEN, Suit.CLUB),
                new Card(Rank.ACE, Suit.DIAMOND),
                new Card(Rank.QUEEN, Suit.DIAMOND),
                new Card(Rank.THREE, Suit.HEART),
                new Card(Rank.ACE, Suit.SPADE),
                new Card(Rank.KING, Suit.SPADE),
                new Card(Rank.TEN, Suit.HEART),
                new Card(Rank.TEN, Suit.SPADE),
                new Card(Rank.TEN, Suit.CLUB),
                new Card(Rank.TEN, Suit.CLUB),
                new Card(Rank.TEN, Suit.DIAMOND),
                new Card(Rank.QUEEN, Suit.HEART),
                new Card(Rank.THREE, Suit.SPADE),
                new Card(Rank.THREE, Suit.DIAMOND),
                new Card(Rank.QUEEN, Suit.SPADE),
            };


            /*ICombination[] combinations = { new Combination.FourOfAkind() };
            CombinationAnalyzer analyzer = combinations;

            ICombination combination = analyzer.CheckUp(cardsFourOfAKind);

            Console.WriteLine(combination.CheckUp(cardsFourOfAKind));*/

            /*var result = new Combination.FourOfAkind().CheckUp(cardsFourOfAKind);

            Console.WriteLine(result);*/
        }

        private static void OnHandChanged()
        {
            var hand = 5;
            var offsetTop = 1;
            /*var name = hand.IsDealer ? "DEALER" : "PLAYER";
            var value = hand.IsDealer ? hand.FaceValue : hand.TotalValue;

            Console.SetCursorPosition(2, hand.IsDealer ? 1 : 13);
            Console.Write(string.Format("{0}'s HAND ({1}):", name, value).PadRight(25));*/

            for (var i = 0; i <= hand; i++)
            {
                var last = i == hand;
                Console.SetCursorPosition(2 + (i * 5), offsetTop + 2);
                Console.Write("┌────" + (last ? "─┐" : string.Empty).PadRight(Console.BufferWidth - 12 - (i * 5)));
                Console.SetCursorPosition(2 + (i * 5), offsetTop + 3);
                /*Console.WriteLine("│" + (hand.Cards[i].IsFaceUp ? hand.Cards[i].ToString() : "XXX").PadRight(4) + 
                    (last ? " │" : string.Empty).PadRight(Console.BufferWidth - 12 - (i * 5)));*/
                Console.SetCursorPosition(2 + (i * 5), offsetTop + 4);
                Console.WriteLine("│".PadRight(5) + (last ? " │" : string.Empty).PadRight(Console.BufferWidth - 12 - (i * 5)));
                Console.SetCursorPosition(2 + (i * 5), offsetTop + 5);
                Console.WriteLine("│".PadRight(5) + (last ? " │" : string.Empty).PadRight(Console.BufferWidth - 12 - (i * 5)));
                Console.SetCursorPosition(2 + (i * 5), offsetTop + 6);
                Console.WriteLine("│".PadRight(5) + (last ? " │" : string.Empty).PadRight(Console.BufferWidth - 12 - (i * 5)));
                Console.SetCursorPosition(2 + (i * 5), offsetTop + 7);
                Console.WriteLine("│".PadRight(5) + (last ? " │" : string.Empty).PadRight(Console.BufferWidth - 12 - (i * 5)));
                Console.SetCursorPosition(2 + (i * 5), offsetTop + 8);
                Console.WriteLine("└────" + (last ? "─┘" : string.Empty).PadRight(Console.BufferWidth - 12 - (i * 5)));
            }
        }

        static void SuitLab()
        {
            const char SPACE = '\u0020';
            const char ZERO = '\u0300';
            char[] suits = new char[4] { '\u2666', '\u2665', '\u2663', '\u2660' };
            char[] firstLetter = new char[4] { 'd', 'h', 'c', 's' };

            string Card(char symbol) => symbol switch
            {
                char s when s is 'd' => string.Concat(suits[0], SPACE, "Diamond"),
                char s when s is 'h' => string.Concat(suits[1], SPACE, "Heart"),
                char s when s is 'c' => string.Concat(suits[2], SPACE, "Club"),
                char s when s is 's' => string.Concat(suits[3], SPACE, "Spade"),
                char s when s is '\u0020' => new Func<string>(() =>
                                                suits.Aggregate(default(string),
                                                                (a, b) => string.Concat(a, b),
                                                                result => string.Join(SPACE, result.ToCharArray())))(),
                char s when s is ZERO or (char)0 or '0' => "zero",
                _ => "undefined"
            };

            string CardByKey(ConsoleKey key) => key switch
            {
                ConsoleKey k when k is ConsoleKey.D => string.Concat(suits[0], SPACE, "Diamond"),
                ConsoleKey k when k is ConsoleKey.H => string.Concat(suits[1], SPACE, "Heart"),
                ConsoleKey k when k is ConsoleKey.C => string.Concat(suits[2], SPACE, "Club"),
                ConsoleKey k when k is ConsoleKey.S => string.Concat(suits[3], SPACE, "Spade"),
                ConsoleKey k when k is ConsoleKey.Spacebar => new Func<string>(() =>
                                                suits.Aggregate(default(string),
                                                                (a, b) => string.Concat(a, b),
                                                                result => string.Join(SPACE, result.ToCharArray())))(),
                ConsoleKey k when k is ConsoleKey.D0 or ConsoleKey.NumPad0 => "Zero",
                ConsoleKey k when k is ConsoleKey.Enter => "Enter",
                ConsoleKey k when k is ConsoleKey.T => MonitorLaunchFunc(0.5, 0.01),
                _ => "undefined"
            };

            ConsoleKeyInfo input;
            do
            {
                Console.Write("Enter a character: ");
                input = Console.ReadKey();
                Console.Clear();
                Console.WriteLine($"\n\tInput character is {CardByKey(input.Key)}");
                Console.SetCursorPosition(0, 0); //try catch
            } while (input.Key != ConsoleKey.Escape);
        }

        static string MonitorLaunchFunc(double time, double pollingInterval)
        {
            try
            {
                var path = @"D:\ARIS\VSGitProjects\MonitorPreLab\bin\Debug\netcoreapp3.1";
                Process.Start(path + @"\MonitorPreLab.exe",
                    new[] { time.ToString(), pollingInterval.ToString(), "telegram" });
            }
            catch
            {
                return "Failed to launch";
            }
            return "Launched";
        }
    }
}
