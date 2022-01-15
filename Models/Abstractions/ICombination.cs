namespace MarvellousPoker.Models.Abstractions
{
    public interface ICombination : IAnalyzer
    {
        bool CheckUp(IReadOnlyCollection<Card> handCards);
    }
}
