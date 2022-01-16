namespace MarvellousPoker.Models
{
    [Flags]
    public enum Rank : byte
    {
        [Description("\x32")] TWO = 0x02,
        [Description("\x33")] THREE = 0x03,
        [Description("\x34")] FOUR = 0x04,
        [Description("\x35")] FIVE = 0x05,
        [Description("\x36")] SIX = 0x06,
        [Description("\x37")] SEVEN = 0x07,
        [Description("\x38")] EIGHT = 0x08,
        [Description("\x39")] NINE = 0x09,
        [Description("10")] TEN = 0x0A,

        [Description("\x4A")] JACK = 0x0B,
        [Description("\x51")] QUEEN = 0x0C,
        [Description("\x4B")] KING = 0x0D,
        [Description("\x41")] ACE = 0x0E,
        //[Description("\x74")] THE_JOKER = 0x0F,
    }
}
