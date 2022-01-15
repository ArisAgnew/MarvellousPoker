namespace MarvellousPoker.Models.Abstractions
{
    public interface IDeck
    {
        ReadOnlyCollection<Card> Cards { get; }

        IDeck Deal();

        Card GetNextCard(); //should be interface returned type

        IDeck Restore();

        void Shuffle<T>(ICollection<T> collection) where T : notnull;
    }
}
