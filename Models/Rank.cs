using System;

using MarvellousPoker.Controllers.Adjuvants;

namespace MarvellousPoker.Models
{
    [Flags]
    public enum Rank : ushort
    {
        [Description("\x32")] TWO = 0b_0000_0010,
        [Description("\x33")] THREE = 0b_0000_0011,
        [Description("\x34")] FOUR = 0b_0000_0100,
        [Description("\x35")] FIVE = 0b_0000_0101,
        [Description("\x36")] SIX = 0b_0000_0110,
        [Description("\x37")] SEVEN = 0b_0000_0111,
        [Description("\x38")] EIGHT = 0b_0000_1000,
        [Description("\x39")] NINE = 0b_0000_1001,
        [Description("10")] TEN = 0b_0000_1010,

        [Description("\x4A")] JACK = 0b_0001_0000,
        [Description("\x51")] QUEEN = 0b_0010_0000,
        [Description("\x4B")] KING = 0b_0100_0000,
        [Description("\x41")] ACE = 0b_1000_0000,
        //[Description("\x74")] THE_JOKER = 0b_100_0000_0000,
    }
}
