namespace MarvellousPoker.Controllers.Strategy
{
    public class CombinationAnalyzer
    {
        private readonly ICombination[] _combinations;

        public CombinationAnalyzer(params ICombination[] combinations) =>
            _combinations = combinations.MightBeNullOrDefault();

        public ICombination CheckUp(IReadOnlyCollection<Card> handCards) =>
            _combinations.FirstOrDefault(c => c.CheckUp(handCards));

        public static implicit operator CombinationAnalyzer(ICombination[] combinations) => new(combinations);
    }
}
