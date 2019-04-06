using RTS2.Navigation;

namespace RTS2.Entity.Components
{
    /// <summary>
    ///     Resolve navigation for an entity
    /// </summary>
    public interface INavigation
    {
        bool Navigate(INavigationMethod navigationMethod, INavigationTarget navigationTarget);
    }
}
