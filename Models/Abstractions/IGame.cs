namespace MarvellousPoker.Models.Abstractions
{
    public interface IGame
    {
        ReadOnlyCollection<long> GameCount { get; }

        void StartGame(); //context

        void DealTheCards(); //context

        void StartRound(); //context

        void FinishRound(); // Reshuffle here

        void FinishGame();
    }
}
