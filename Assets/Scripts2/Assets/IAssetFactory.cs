namespace RTS2.Assets
{
    public interface IAssetFactory
    {
        UnityEngine.GameObject GetAssetPrefab(EAssetType assetType, string assetIdentifier);
    }
}
