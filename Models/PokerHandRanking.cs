using System;

using MarvellousPoker.Controllers.Adjuvants;

namespace MarvellousPoker.Models
{
    [Flags]
    public enum PokerHandRanking : ushort
    {
        [Specimen("4♣", "7♦", "A♣", "10♥", "Q♠"), Description("High hand")]
        HIGH_HAND = 0,

        [Specimen("A♣", "A♦", "Q♥", "2♥", "9♠"), Description("One pair")]
        ONE_PAIR = 1,

        [Specimen("A♣", "A♥", "K♥", "K♣", "8♠"), Description("Two pair")]
        TWO_PAIR = 2,

        [Specimen("A♣", "A♦", "A♠", "5♥", "7♣"), Description("Three of a kind")]
        THREE_OF_A_KIND = 4,

        [Specimen("10♦", "9♥", "8♣", "7♠", "6♣"), Description("Straight")]
        STRAIGHT = 8,

        [Specimen("9♦", "Q♦", "4♦", "5♦", "10♦"), Description("Flush")]
        FLUSH = 16,

        [Specimen("A♣", "A♦", "A♥", "♣", "K♦"), Description("Full house")]
        FULL_HOUSE = 32,

        [Specimen("A♦", "A♥", "A♣", "A♠", "10♣"), Description("Four of a kind")]
        FOUR_OF_A_KIND = 64,

        [Specimen("10♣", "9♣", "8♣", "7♣", "6♣"), Description("Straight flush")]
        STRAIGHT_FLUSH = 128,

        [Specimen("A♣", "K♣", "Q♣", "J♣", "10♣"), Description("Royal flush")]
        ROYAL_FLUSH = 256
    }
}
