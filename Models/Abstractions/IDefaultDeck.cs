namespace MarvellousPoker.Models
{
    public interface IDefaultDeck<out T>
    {
        IReadOnlyCollection<T> GetBrandNewDeck();
    }
}
