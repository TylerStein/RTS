namespace RTS2.Entity.Components
{
    /// <summary>
    ///     Hold on to the display name and identifier for an entity
    /// </summary>
    public interface IEntityIdentifier
    {
        string GetDisplayName();
        string GetAssetIdentifier();
    }
}